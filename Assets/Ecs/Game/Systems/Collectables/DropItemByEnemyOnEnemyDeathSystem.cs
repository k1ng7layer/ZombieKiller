using System.Collections.Generic;
using Db.Enemies;
using Db.Items;
using Db.LootParams;
using Ecs.Commands;
using Game.Providers.RandomProvider;
using Game.Utils;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Collectables
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 950, nameof(EFeatures.Combat))]
    public class DropItemByEnemyOnEnemyDeathSystem : ReactiveSystem<GameEntity>
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly IEnemyParamsBase _enemyParamsBase;
        private readonly IRandomProvider _randomProvider;
        private readonly IItemsBase _itemsBase;

        public DropItemByEnemyOnEnemyDeathSystem(
            GameContext game, 
            ICommandBuffer commandBuffer,
            IEnemyParamsBase enemyParamsBase,
            IRandomProvider randomProvider,
            IItemsBase itemsBase
        ) : base(game)
        {
            _commandBuffer = commandBuffer;
            _enemyParamsBase = enemyParamsBase;
            _randomProvider = randomProvider;
            _itemsBase = itemsBase;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Dead);

        protected override bool Filter(GameEntity entity) => entity.IsDead && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var enemyParams = _enemyParamsBase.GetEnemyParams(entity.Enemy.EnemyType);
                
                foreach (var lootParams in enemyParams.LootPreset.LootPresets)
                {
                    var items = GetLootItems(lootParams);

                    foreach (var itemId in items)
                    {
                        _commandBuffer.DropItem(new CollectableInfo(itemId, 
                            entity.Position.Value)); 
                    }
                }
            }
        }

        private List<string> GetLootItems(LootParams lootParams)
        {
            var itemsId = new List<string>();
                    
            if (lootParams.ItemType == EItemType.Any)
            {
                itemsId.Add(GetRandomItem(_itemsBase.Items).Id);
            }
            else
            {
                GetLootItemsByType(lootParams, itemsId);
            }

            return itemsId;
        }

        private void GetLootItemsByType(LootParams lootParams, List<string> result)
        {
            if (lootParams.ItemsIds.Count == 0)
            {
                var items = _itemsBase.GetItemsByType(lootParams.ItemType);
                result.Add(GetRandomItem(items).Id);
            }
            else
            {
                GetItemIdsFromLootPresetParams(result, lootParams);
            }
        }

        private void GetItemIdsFromLootPresetParams(List<string> result, LootParams lootParams)
        {
            if (lootParams.IsRandom)
            {
                var randomItemIndex = _randomProvider.Range(0, lootParams.ItemsIds.Count);
                result.Add(lootParams.ItemsIds[randomItemIndex]);
            }
            else
            {
                result.AddRange(lootParams.ItemsIds);
            }
        }
        
        private Db.Items.Item GetRandomItem(IReadOnlyList<Db.Items.Item> items)
        {
            var randomItemIndex = _randomProvider.Range(0, items.Count);
            var randomItemId = items[randomItemIndex];

            return randomItemId;
        }
        
    }
}