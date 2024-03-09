using Ecs.Commands;
using Ecs.Utils.Groups;
using Game.Utils;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Game.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 240, nameof(EFeatures.Combat))]
    public class ArtilleryShotTrajectorySystem : IUpdateSystem
    {
        private readonly IGameGroupUtils _gameGroupUtils;
        private readonly ICommandBuffer _commandBuffer;

        public ArtilleryShotTrajectorySystem(
            IGameGroupUtils gameGroupUtils, 
            ICommandBuffer commandBuffer
        )
        {
            _gameGroupUtils = gameGroupUtils;
            _commandBuffer = commandBuffer;
        }
        
        public void Update()
        {
            using var projectilesGroup = _gameGroupUtils.GetProjectiles(out var projectiles, 
                p => p.HasTrajectory);

            foreach (var projectile in projectiles)
            {
                var trajectoryInfo =  projectile.Trajectory.Value;
                var nextPoint = trajectoryInfo.Waypoints[trajectoryInfo.NextPoint];
                var pos = projectile.Position.Value;

                //Debug.Log($"ArtilleryShotTrajectorySystem. dist: {(nextPoint - pos).sqrMagnitude}, check: {0.1f * 0.1f} next point: {trajectoryInfo.NextPoint} ");
                if ((nextPoint - pos).sqrMagnitude <= 0.1f * 0.1f)
                {
                    if (trajectoryInfo.NextPoint + 1 < trajectoryInfo.Waypoints.Length)
                    {
                        var next = trajectoryInfo.NextPoint + 1;

                        var destination = trajectoryInfo.Waypoints[next];
                        var dir = destination - pos;
                        var rot = Quaternion.LookRotation(dir);
                        projectile.ReplaceRotation(rot);
                        projectile.ReplaceTrajectory(new TrajectoryInfo(trajectoryInfo.Waypoints, next));
                        projectile.ReplaceDestination(destination);
                    }
                    else
                    {
                        _commandBuffer.CreateExplosion(nextPoint, EExplosionType.Fire, projectile.Owner.Value, 100f);
                    }
                }
            }
        }
    }
}