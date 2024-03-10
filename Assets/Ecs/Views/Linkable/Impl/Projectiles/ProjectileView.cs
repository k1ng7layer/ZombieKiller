using Ecs.Commands;
using Ecs.Utils.LinkedEntityRepository;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using JCMG.EntitasRedux.Core.Utils;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Ecs.Views.Linkable.Impl.Projectiles
{
    public class ProjectileView : ObjectView
    {
        [SerializeField] private Collider touchTrigger;
        [SerializeField] private GameObject mainFx;

        [Inject] private ICommandBuffer _commandBuffer;
        [Inject] private ILinkedEntityRepository _linkedEntityRepository;

        public void SetState(bool v)
        {
            touchTrigger.enabled = v;
        }

        public void SetVisibility(bool value)
        {
            if (value)
                OnVisibleAdded();
            else OnVisibleRemoved();
        }
        
        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            var projectileEntity = (GameEntity)entity;

            projectileEntity.SubscribeDead(OnDead).AddTo(unsubscribe);
            projectileEntity.SubscribeActive(OnActiveAdded).AddTo(unsubscribe);
            projectileEntity.SubscribeActiveRemoved(OnActiveRemoved).AddTo(unsubscribe);
            projectileEntity.SubscribeVisible(_ => OnVisibleAdded()).AddTo(unsubscribe);
            projectileEntity.SubscribeVisibleRemoved(_ => OnVisibleRemoved()).AddTo(unsubscribe);
            
            touchTrigger.OnTriggerEnterAsObservable().Subscribe(OnProjectileTouch).AddTo(unsubscribe);

            SetState(false);
        }

        private void OnActiveAdded(GameEntity _)
        {
            SetState(true);
        }
        
        private void OnActiveRemoved(GameEntity _)
        {
            SetState(false);
        }

        private void OnVisibleAdded()
        {
            mainFx.SetActive(true);
        }
        
        private void OnVisibleRemoved()
        {
            mainFx.SetActive(false);
        }

        private void OnProjectileTouch(Collider other)
        {
            if (!_linkedEntityRepository.Contains(other.transform.GetHashCode()))
            {
                _commandBuffer.DestroyProjectile(transform.GetHashCode());
            }
            
            //_commandBuffer.DestroyProjectile(transform.GetHashCode());
        }

        protected virtual void OnDead(GameEntity _)
        {
            
        }

        protected override void OnClear()
        {
            
        }
    }
}