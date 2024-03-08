using System;
using System.Collections.Generic;
using Db.Enemies;
using Ecs.Commands;
using Ecs.Views.Linkable.Impl;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Enemy
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 550, nameof(EFeatures.Spawn))]
    public class InitializeEnemyWeaponSystem : ReactiveSystem<GameEntity>
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly IEnemyParamsBase _enemyParamsBase;

        public InitializeEnemyWeaponSystem(
            GameContext game, 
            ICommandBuffer commandBuffer, 
            IEnemyParamsBase enemyParamsBase
        ) : base(game)
        {
            _commandBuffer = commandBuffer;
            _enemyParamsBase = enemyParamsBase;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Link.Added());

        protected override bool Filter(GameEntity entity) 
            => entity.HasEnemy && !entity.HasWeapon && entity.HasWeaponRoot && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var enemyView = (EnemyView)entity.Link.View;
                
                var enemyParams = _enemyParamsBase.GetEnemyParams(entity.Enemy.EnemyType);

                if (enemyParams.Weapon != string.Empty && enemyView.Weapon != null)
                {
                    _commandBuffer.EquipWeapon(enemyParams.Weapon, entity.Uid.Value, enemyParams.SpawnWeapon);
                }
            }
        }
    }
}