using Ecs.Core.Interfaces;
using Ecs.Utils.Groups;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Projectile
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 700, nameof(EFeatures.Combat))]
    public class ProjectileMovementSystem : IUpdateSystem
    {
        private readonly IGameGroupUtils _gameGroupUtils;
        private readonly ITimeProvider _timeProvider;

        public ProjectileMovementSystem(
            IGameGroupUtils gameGroupUtils, 
            ITimeProvider timeProvider
        )
        {
            _gameGroupUtils = gameGroupUtils;
            _timeProvider = timeProvider;
        }
        
        public void Update()
        {
            using var projectileGroup = _gameGroupUtils.GetProjectiles(out var projectiles);

            foreach (var projectile in projectiles)
            {
                var speed = projectile.Speed.Value;
                var dir = projectile.Transform.Value.forward;
                var movement = dir * speed * _timeProvider.DeltaTime;
                var position = projectile.Position.Value;
                position += movement;
                
                projectile.ReplacePosition(position);
            }
        }
    }
}