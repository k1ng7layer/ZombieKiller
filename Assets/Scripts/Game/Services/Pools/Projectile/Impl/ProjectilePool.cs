using Ecs.Views.Linkable.Impl.Projectiles;
using Game.Utils;
using UnityEngine;
using Zenject;

namespace Game.Services.Pools.Projectile.Impl
{
    public class ProjectilePool : MemoryPool<ProjectileView>, IProjectilePool
    {
        private static readonly Vector3 DefaultPosition = new Vector3(0, -5000, 0);
        
        public ProjectilePool(EProjectileType projectileType)
        {
            ProjectileType = projectileType;
        }
        
        public EProjectileType ProjectileType { get; }
        

        protected override void OnCreated(ProjectileView item)
        {
            base.OnCreated(item);

            item.SetState(true);

            item.transform.position = DefaultPosition;
        }

        protected override void OnDespawned(ProjectileView item)
        {
            base.OnDespawned(item);
            
            item.SetState(false);
            
            item.transform.position = DefaultPosition;
        }
    }
}