using Db.Items;
using Db.Loot;
using Ecs.Commands.Command;
using Game.Providers.RandomProvider;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 960, nameof(EFeatures.Combat))]
    public class DropItemSystem : ForEachCommandUpdateSystem<DropItemCommand>
    {
        private readonly IRandomProvider _randomProvider;
        private readonly IItemsBase _itemsBase;
        private readonly ILootSettings _lootSettings;
        private readonly GameContext _game;

        public DropItemSystem(
            ICommandBuffer commandBuffer,
            IRandomProvider randomProvider,
            IItemsBase itemsBase,
            ILootSettings lootSettings,
            GameContext game
        ) : base(commandBuffer)
        {
            _randomProvider = randomProvider;
            _itemsBase = itemsBase;
            _lootSettings = lootSettings;
            _game = game;
        }

        protected override void Execute(ref DropItemCommand command)
        {
            var collectable = _game.CreateEntity();
            collectable.AddPosition(command.Info.DropCenter);
            collectable.AddRotation(Quaternion.identity);
            collectable.AddCollectable(command.Info);
            var itemSettings = _itemsBase.GetItem(command.Info.ItemId);
            collectable.AddPrefab(itemSettings.Name);

            var dir = Vector3.up * _lootSettings.InitialVelocityMultiplier;
            dir += new Vector3(_randomProvider.Range(-1f, 1f), 0f, _randomProvider.Range(-1f, 1f));
            
            collectable.ReplaceMoveDirection(dir);
            collectable.IsInstantiate = true;
        }
    }
}