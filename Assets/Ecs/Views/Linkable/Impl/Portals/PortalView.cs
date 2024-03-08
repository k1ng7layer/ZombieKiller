using Ecs.Commands;
using Ecs.Utils;
using Ecs.Utils.LinkedEntityRepository;
using Game.Utils;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using JCMG.EntitasRedux.Core.Utils;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Ecs.Views.Linkable.Impl.Portals
{
    public class PortalView : ObjectView
    {
        [SerializeField] private Collider _playerTrigger;
        [SerializeField] private EPortalDestination portalDestination;
        [SerializeField] private bool activeOnStart;
        
        [Inject] private ILinkedEntityRepository _linkedEntityRepository;
        [Inject] private ICommandBuffer _commandBuffer;

        public EPortalDestination PortalDestination => portalDestination;
        
        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            _playerTrigger.OnTriggerEnterAsObservable().Subscribe(OnPlayerEnteredPortal).AddTo(unsubscribe);

            var portalEntity = (GameEntity)entity;
            
            portalEntity.SubscribeActive(_ => OnActiveChanged(true)).AddTo(unsubscribe);
            portalEntity.SubscribeActiveRemoved(_ => OnActiveChanged(false)).AddTo(unsubscribe);

            OnActiveChanged(activeOnStart);
        }

        private void OnPlayerEnteredPortal(Collider other)
        {
            if (LayerMask.GetMask(LayerNames.Units) == (LayerMask.GetMask(LayerNames.Units) 
                                                         | 1 << other.gameObject.layer))
            {
                var unitHash = other.transform.GetHashCode();

                var unit = _linkedEntityRepository.Get(unitHash);
                
                if (!unit.IsPlayer)
                    return;
                
                _commandBuffer.TeleportPlayer(transform.GetHashCode());
            }
        }

        private void OnActiveChanged(bool v)
        {
            gameObject.SetActive(v);
        }
    }
}