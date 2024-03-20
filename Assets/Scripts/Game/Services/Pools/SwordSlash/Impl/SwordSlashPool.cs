using UnityEngine;
using Zenject;

namespace Game.Services.Pools.SwordSlash.Impl
{
    public class SwordSlashPool : MemoryPool<ParticleSystem>, 
        ISwordSlashPool
    {
        private static readonly Vector3 DefaultPosition = new Vector3(0, -5000, 0);
        
        protected override void OnCreated(ParticleSystem item)
        {
            base.OnCreated(item);

            item.transform.position = DefaultPosition;
        }

        protected override void OnDespawned(ParticleSystem item)
        {
            base.OnDespawned(item);
            
            item.transform.position = DefaultPosition;
        }
    }
}