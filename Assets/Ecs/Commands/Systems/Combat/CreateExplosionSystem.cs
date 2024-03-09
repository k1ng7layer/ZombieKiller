using System;
using System.Collections.Generic;
using Ecs.Commands.Command.Combat;
using Ecs.Utils.Groups;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 250, nameof(EFeatures.Combat))]
    public class CreateExplosionSystem : ForEachCommandUpdateSystem<CreateExplosionCommand>
    {
        private readonly IGameGroupUtils _gameGroupUtils;
        private readonly GameContext _game;

        public CreateExplosionSystem(
            ICommandBuffer commandBuffer, 
            IGameGroupUtils gameGroupUtils,
            GameContext game
        ) : base(commandBuffer)
        {
            _gameGroupUtils = gameGroupUtils;
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