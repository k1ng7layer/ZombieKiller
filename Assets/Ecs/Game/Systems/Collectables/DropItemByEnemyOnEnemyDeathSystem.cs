using System.Collections.Generic;
using Db.Enemies;
using Ecs.Commands;
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

        public DropItemByEnemyOnEnemyDeathSystem(
            GameContext game, 
            ICommandBuffer commandBuffer,
            IEnemyParamsBase enemyParamsBase
        ) : base(game)
        {
            _commandBuffer = commandBuffer;
            _enemyParamsBase = enemyParamsBase;
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
                    foreach (var itemId in lootParams.ItemsIds)
                    {
                        _commandBuffer.DropItem(
                            new CollectableInfo(
                                lootParams.ItemType, 
                                itemId, 
                                entity.Position.Value
                                ));
                    }   
                }
            }
        }
    }
}