using Ecs.Commands;
using Ecs.Utils.Groups;
using Game.Utils;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Projectile
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 600, nameof(EFeatures.Combat))]
    public class ProjectileSpotExplosionSystem : IUpdateSystem
    {
        private readonly IGameGroupUtils _gameGroupUtils;
        private readonly ICommandBuffer _commandBuffer;
        private readonly GameContext _game;

        public ProjectileSpotExplosionSystem(
            IGameGroupUtils gameGroupUtils, 
            ICommandBuffer commandBuffer, 
            GameContext game
        )
        {
            _gameGroupUtils = gameGroupUtils;
            _commandBuffer = commandBuffer;
            _game = game;
        }
        
        public void Update()
        {
            using var group = _gameGroupUtils.GetProjectiles(out var projectiles, 
                p => p.HasVfx && p.IsVisible);

            foreach (var projectile in projectiles)
            {
                var spot = _game.GetEntityWithUid(projectile.Vfx.VfxUid);
                
                var destination = spot.Position.Value;
                var projectilePos = projectile.Position.Value;

                var dist2 = (destination - projectilePos).sqrMagnitude;

                if (dist2 <= 1f * 1f)
                {
                    _commandBuffer.CreateExplosion(destination, 
                        EExplosionType.FireExplosion, 
                        projectile.Owner.Value, 
                        3f,
                        10f);

                    projectile.IsVisible = false;
                    _commandBuffer.DestroyProjectile(projectile.Transform.Value.GetHashCode());
                }
            }
        }
    }
}