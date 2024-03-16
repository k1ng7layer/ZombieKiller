using System.Collections.Generic;
using Db.Player;
using Ecs.Utils.Groups;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Game.Systems.Player
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 200, nameof(EFeatures.Combat))]
    public class RotatePlayerToEnemyOnAttackSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGameGroupUtils _gameGroupUtils;
        private readonly IPlayerSettings _playerSettings;

        public RotatePlayerToEnemyOnAttackSystem(
            GameContext game, 
            IGameGroupUtils gameGroupUtils,
            IPlayerSettings playerSettings
        ) : base(game)
        {
            _gameGroupUtils = gameGroupUtils;
            _playerSettings = playerSettings;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.PerformingAttack);

        protected override bool Filter(GameEntity entity) =>
            entity.IsPlayer && entity.IsPerformingAttack && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (!TryGetNearestEnemy(entity, out var enemy))
                    continue;

                var dir = enemy.Position.Value - entity.Position.Value;
                
                if (dir.sqrMagnitude >= _playerSettings.RotateDistToEnemy * _playerSettings.RotateDistToEnemy)
                    continue;

                var rotation = Quaternion.LookRotation(dir, Vector3.up);
                
                entity.ReplaceRotation(rotation);
            }
        }

        private bool TryGetNearestEnemy(GameEntity player, out GameEntity closest)
        {
            using var enemiesGroup = _gameGroupUtils.GetUnits(out var enemies, u => u.HasEnemy && !u.IsDead);

            float nearestDist = float.MaxValue;
            GameEntity nearest = null;

            var playerPos = player.Position.Value;
            
            foreach (var enemy in enemies)
            {
                var dist2 = (enemy.Position.Value - playerPos).sqrMagnitude;
                
                if (dist2 <= nearestDist)
                {
                    nearestDist = dist2;
                    nearest = enemy;
                }
            }

            closest = nearest;
            
            return true;
        }
    }
}