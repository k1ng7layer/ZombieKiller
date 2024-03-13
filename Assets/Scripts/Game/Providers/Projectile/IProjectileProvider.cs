using Ecs.Extensions.UidGenerator;
using Game.Utils;
using UnityEngine;

namespace Game.Providers.Projectile
{
    public interface IProjectileProvider
    {
        GameEntity CreateProjectileWithTrajectory(
            Uid Shooter, 
            Vector3 Origin, 
            Vector3[] Trajectory, 
            EProjectileType ProjectileType, 
            float Speed);
    }
}