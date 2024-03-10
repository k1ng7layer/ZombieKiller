using Ecs.Views.Linkable.Impl;
using Game.Utils;
using UnityEngine;
using Zenject;

namespace Game.Services.Pools.Explosion.Impl
{
    public class ExplosionPool : MemoryPool<ExplosionView>, IExplosionPool
    {
        private static readonly Vector3 DefaultPosition = new(0, -5000, 0);
        
        public ExplosionPool(EExplosionType explosionType)
        {
            ExplosionType = explosionType;
        }

        public EExplosionType ExplosionType { get; }

        protected override void OnCreated(ExplosionView item)
        {
            base.OnCreated(item);
            
            item.transform.position = DefaultPosition;
        }

        protected override void OnSpawned(ExplosionView item)
        {
            base.OnSpawned(item);
            
            item.Init(ExplosionType);
        }

        protected override void OnDespawned(ExplosionView item)
        {
            base.OnDespawned(item);
            
            item.Hide();
            item.transform.position = DefaultPosition;
        }
    }
}