using AnimationTriggers;
using Ecs.Commands;
using Ecs.Utils;
using Game.Utils;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using JCMG.EntitasRedux.Core.Utils;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Ecs.Views.Linkable.Impl
{
    public class UnitView : ObjectView
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] protected Animator _animator;
        [SerializeField] private Collider _damageTrigger;
        
        [Inject] private ICommandBuffer _commandBuffer;

        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            var unitEntity = (GameEntity)entity;
            
            unitEntity.SubscribeMoveDirection(OnDirectionChanged).AddTo(unsubscribe);
            unitEntity.SubscribePerformingAttack(OnPerformingAttack).AddTo(unsubscribe);
            unitEntity.SubscribeDead(OnDead).AddTo(unsubscribe);

            _damageTrigger.OnTriggerEnterAsObservable().Subscribe(OnUnitTriggerEnter).AddTo(unsubscribe);
            
            var attackEndTrigger = _animator.GetBehaviour<CompleteAttackTrigger>();
            
            attackEndTrigger?.AttackEnd.Subscribe(_ =>
            {
                _commandBuffer.CompletePerformingAttack(unitEntity.Uid.Value);
            }).AddTo(gameObject);

            attackEndTrigger?.AttackStart.Subscribe(_ =>
            {
                _commandBuffer.PerformAttack(unitEntity.Uid.Value);
            });
        }

        private void OnDirectionChanged(GameEntity entity, Vector3 dir)
        {
            entity.Position.Value = transform.position;
            _rb.velocity = dir;
            Debug.Log($"OnDirectionChanged: AnimationKeys.Movement {dir.magnitude}");
            _animator.SetFloat(AnimationKeys.Movement, dir.normalized.magnitude, 0.02f, Time.deltaTime);
        }

        private void OnPerformingAttack(GameEntity entity)
        {
            _animator.SetTrigger(AnimationKeys.Attack);
        }

        private void OnUnitTriggerEnter(Collider other)
        {
            if (LayerMask.GetMask(LayerNames.Weapon) == (LayerMask.GetMask(LayerNames.Weapon) 
                                               | 1 << other.gameObject.layer))
            {
                var weaponHash = other.transform.GetHashCode();
                
                _commandBuffer.TakeDamage(weaponHash, transform.GetHashCode());
            }
        }

        protected virtual void OnDead(GameEntity _)
        {
            _damageTrigger.enabled = false;
            _animator.SetTrigger(AnimationKeys.Death);
        }
    }
}