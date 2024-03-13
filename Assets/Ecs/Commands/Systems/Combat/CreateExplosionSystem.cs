using System;
using System.Collections.Generic;
using Ecs.Commands.Command.Combat;
using Ecs.Utils.Groups;
using Game.Services.ExplosionPoolRepository;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UniRx;

namespace Ecs.Commands.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 250, nameof(EFeatures.Combat))]
    public class CreateExplosionSystem : ForEachCommandUpdateSystem<CreateExplosionCommand>
    {
        private readonly IGameGroupUtils _gameGroupUtils;
        private readonly IExplosionPoolRepository _explosionPoolRepository;
        private readonly GameContext _game;

        public CreateExplosionSystem(
            ICommandBuffer commandBuffer, 
            IGameGroupUtils gameGroupUtils,
            IExplosionPoolRepository explosionPoolRepository,
            GameContext game
        ) : base(commandBuffer)
        {
            _gameGroupUtils = gameGroupUtils;
            _explosionPoolRepository = explosionPoolRepository;
            _game = game;
        }

        protected override void Execute(ref CreateExplosionCommand command)
        {
            using var targetsGroup =
                GetExplosionTargets(out var targets, _game.GetEntityWithUid(command.Owner).IsPlayer);

            // var explosion = _game.CreateEntity();
            // explosion.AddPrefab("FireExplosion");
            // explosion.AddPosition(command.Origin);
            // explosion.IsInstantiate = true;
            
            foreach (var target in targets)
            {
                var dist2 = (target.Position.Value - command.Origin).sqrMagnitude;
                
                var explosionPool = _explosionPoolRepository.Get(command.ExplosionType);
                var explosionView = explosionPool.Spawn();
                explosionView.transform.position = command.Origin;
                
                Observable.Timer(TimeSpan.FromSeconds(explosionView.LifeTime)).Subscribe(_ =>
                {
                    explosionPool.Despawn(explosionView);
                });
                
                if (dist2 > command.Radius * command.Radius)
                    continue;
                
                var damage = command.Damage;
                var health = target.Health.Value;
                health -= damage;
            
                target.ReplaceHealth(health);

                if (!target.HasHitCounter)
                {
                    target.AddHitCounter(0);
                }
                else
                {
                    var hitCounter = target.HitCounter.Value;
                    target.ReplaceHitCounter(++hitCounter);
                }
            }
        }

        private IDisposable GetExplosionTargets(out List<GameEntity> entities, bool isFriendly)
        {
            return isFriendly ? _gameGroupUtils.GetUnits(out entities, u => u.HasEnemy) : 
                _gameGroupUtils.GetUnits(out entities, u => u.IsPlayer);
        }
    }
}