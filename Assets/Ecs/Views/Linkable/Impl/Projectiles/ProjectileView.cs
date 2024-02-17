using Ecs.Commands;
using Ecs.Utils;
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
        [SerializeField] private GameObject _fx;

        [Inject] private ICommandBuffer _commandBuffer;

        public void SetState(bool v)
        {
            _fx.SetActive(v);
        }
        
        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            var projectileEntity = (GameEntity)entity;

            projectileEntity.SubscribeDead(OnDead).AddTo(unsubscribe);
            projectileEntity.SubscribeActive(OnActiveAdded).AddTo(unsubscribe);
            projectileEntity.SubscribeActiveRemoved(OnActiveRemoved).AddTo(unsubscribe);
            
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

        private void OnProjectileTouch(Collider other)
        {
            var isEnv = LayerMask.GetMask(LayerNames.Environment) == (LayerMask.GetMask(LayerNames.Environment)
                                                                            | 1 << other.gameObject.layer);
            
            var isUnits = LayerMask.GetMask(LayerNames.Units) == (LayerMask.GetMask(LayerNames.Units)
                                                                        | 1 << other.gameObject.layer);
            if (isEnv || isUnits)
            {
                var targetHash = other.transform.GetHashCode();
                
                _commandBuffer.DestroyProjectile(transform.GetHashCode(), targetHash);
            }
        }

        protected virtual void OnDead(GameEntity _)
        {
            
        }

        protected override void OnClear()
        {
            
        }
    }
}