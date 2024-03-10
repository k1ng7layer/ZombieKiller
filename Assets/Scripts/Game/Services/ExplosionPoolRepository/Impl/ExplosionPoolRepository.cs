using System;
using System.Collections.Generic;
using Game.Services.Pools.Explosion;
using Game.Utils;

namespace Game.Services.ExplosionPoolRepository.Impl
{
    public class ExplosionPoolRepository : IExplosionPoolRepository
    {
        private readonly Dictionary<EExplosionType, IExplosionPool> _projectilePools = new();
        
        public ExplosionPoolRepository(List<IExplosionPool> projectilePools)
        {
            foreach (var projectilePool in projectilePools)
            {
                _projectilePools.Add(projectilePool.ExplosionType, projectilePool);
            }
        }
        
        public IExplosionPool Get(EExplosionType projectileType)
        {
            if (!_projectilePools.ContainsKey(projectileType))
                throw new Exception(
                    $"[{nameof(ProjectilePoolRepository)}] cant find projectile pool for projectile type {projectileType}");

            return _projectilePools[projectileType];
        }
    }
}