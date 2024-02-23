using AnimationTriggers;
using Db.Weapon;
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
        [SerializeField] protected GameObject weaponRoot;
        [SerializeField] private Rigidbody _rb;
        [SerializeField] protected Animator _animator;
        [SerializeField] private Collider _damageTrigger;
        
        [Inject] private ICommandBuffer _commandBuffer;
        [Inject] private IWeaponBase _weaponBase;

        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            var unitEntity = (GameEntity)entity;
            
            unitEntity.SubscribeMoveDirection(OnDirectionChanged).AddTo(unsubscribe);
            unitEntity.SubscribePerformingAttack(OnPerformingAttack).AddTo(unsubscribe);
            unitEntity.SubscribeDead(OnDead).AddTo(unsubscribe);
            unitEntity.ReplaceWeaponRoot(weaponRoot.transform);
            unitEntity.SubscribeHitCounter(OnHitCounterChanged).AddTo(unsubscribe);
            
            _damageTrigger.OnTriggerEnterAsObservable().Subscribe(OnUnitTriggerEnter).AddTo(unsubscribe);
            
            var attackEndTriggers = _animator.GetBehaviours<CompleteAttackTrigger>();

            foreach (var attackEndTrigger in attackEndTriggers)
            {
                attackEndTrigger?.AttackEnd.Subscribe(_ =>
                {
                    _commandBuffer.CompletePerformingAttack(unitEntity.Uid.Value);
                }).AddTo(gameObject);
                
                
                attackEndTrigger?.AttackStart.Subscribe(_ =>
                {
                    _commandBuffer.PerformAttack(unitEntity.Uid.Value);
                });
            }
        }

        protected virtual void OnDirectionChanged(GameEntity entity, Vector3 dir)
        {
            entity.Position.Value = transform.position;
            _rb.velocity = dir;
            Debug.Log($"OnDirectionChanged: AnimationKeys.Movement {dir.magnitude}");
            _animator.SetFloat(AnimationKeys.Movement, dir.normalized.magnitude, 0.02f, Time.deltaTime);
        }

        private void OnPerformingAttack(GameEntity entity)
        {
            var weaponId = entity.EquippedWeapon.Value.Id;
            int paramId;
            
            paramId = _weaponBase.GetWeapon(weaponId).WeaponType == EWeaponType.Melee ? AnimationKeys.Attack : AnimationKeys.RangedAttack;
            
            _animator.SetTrigger(paramId);
        }

        private void OnUnitTriggerEnter(Collider other)
        {
            if (LayerMask.GetMask(LayerNames.Weapon) == (LayerMask.GetMask(LayerNames.Weapon) 
                                               | 1 << other.gameObject.layer))
            {
                var weaponHash = other.transform.GetHashCode();
                
                _commandBuffer.TakeDamageByWeapon(weaponHash, transform.GetHashCode());
            }
        }

        protected virtual void OnDead(GameEntity _)
        {
            _damageTrigger.enabled = false;
            _animator.SetTrigger(AnimationKeys.Death);
        }

        private void OnHitCounterChanged(GameEntity entity, int value)
        {
            _animator.SetTrigger(AnimationKeys.TakeDamage);
        }
    }
}