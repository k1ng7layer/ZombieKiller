using Ecs.Views.Linkable.Impl.Spots;
using UnityEngine;
using Zenject;

namespace Game.Services.Pools.Spot
{
    public class SpotPool : MemoryPool<SpotView>, ISpotPool
    {
        private static readonly Vector3 DefaultPosition = new Vector3(0, -5000, 0);

        protected override void OnCreated(SpotView item)
        {
            base.OnCreated(item);

            item.SetState(false);

            item.transform.position = DefaultPosition;
        }

        protected override void OnDespawned(SpotView item)
        {
            base.OnDespawned(item);
            
            item.SetState(false);
            
            item.transform.position = DefaultPosition;
        }

        protected override void OnSpawned(SpotView item)
        {
            base.OnSpawned(item);
            
            item.SetState(true);
        }
    }
}