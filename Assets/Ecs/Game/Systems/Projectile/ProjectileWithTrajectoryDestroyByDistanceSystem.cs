using Ecs.Commands;
using Ecs.Utils.Groups;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Projectile
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 710, nameof(EFeatures.Combat))]
    public class ProjectileWithTrajectoryDestroyByDistanceSystem : IUpdateSystem
    {
        private readonly IGameGroupUtils _gameGroupUtils;
        private readonly ICommandBuffer _commandBuffer;
        private readonly GameContext _game;

        public ProjectileWithTrajectoryDestroyByDistanceSystem(
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
            using var group = _gameGroupUtils.GetProjectiles(out var projectiles, p => p.HasTrajectory);

            foreach (var projectile in projectiles)
            {
                var destination = projectile.Destination.Value;
                var projectilePos = projectile.Position.Value;
                var trajectory = projectile.Trajectory.Value;
                var dist2 = (destination - projectilePos).sqrMagnitude;

               // Debug.Log($"trajectory.NextPoint: {trajectory.NextPoint}, trajectory.Waypoints.Length: {trajectory.Waypoints.Length}, dist2: {dist2}");
                //Debug.Log($"NextPoint: {trajectory.NextPoint}, Waypoints.Length: {trajectory.Waypoints.Length}, dist2: {dist2}, destination: {destination}");
                if (dist2 <= 0.8f * 0.8f && trajectory.NextPoint == trajectory.Waypoints.Length - 1)
                {
                    _commandBuffer.DestroyProjectile(projectile.Transform.Value.GetHashCode());
                }

                var owner = _game.GetEntityWithUid(projectile.Owner.Value);
                var ownerPos = owner.Position.Value;
                var distToOwner2 = (ownerPos - projectilePos).sqrMagnitude;

                if (distToOwner2 >= 150 * 150 && trajectory.NextPoint == trajectory.Waypoints.Length)
                {
                    _commandBuffer.DestroyProjectile(projectile.Transform.Value.GetHashCode());
                }
                
            }
        }
    }
}