using System;
using System.Collections.Generic;
using Game.Services.Pools.Projectile;
using Game.Utils;

namespace Game.Services.ProjectilePoolRepository.Impl
{
    public class ProjectilePoolRepository : IProjectilePoolRepository
    {
        private readonly Dictionary<EProjectileType, IProjectilePool> _projectilePools = new();
        
        public ProjectilePoolRepository(List<IProjectilePool> projectilePools)
        {
            foreach (var projectilePool in projectilePools)
            {
                _projectilePools.Add(projectilePool.ProjectileType, projectilePool);
            }
        }
        
        public IProjectilePool GetPool(EProjectileType projectileType)
        {
            if (!_projectilePools.ContainsKey(projectileType))
                throw new Exception(
                    $"[{nameof(ProjectilePoolRepository)}] cant find projectile pool for projectile type {projectileType}");

            return _projectilePools[projectileType];
        }
    }
}