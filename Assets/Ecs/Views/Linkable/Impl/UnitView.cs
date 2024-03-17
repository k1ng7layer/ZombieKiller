using AnimationTriggers;
using Db.Items.Repositories;
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
        [SerializeField] private ParticleSystem _onHitFx;
        [SerializeField] protected GameObject weaponRoot;
        [SerializeField] protected Rigidbody _rb;
        [SerializeField] protected Animator _animator;
        [SerializeField] protected Collider _damageTrigger;
        [SerializeField] protected Collider _rootCollider;
        [SerializeField] private WeaponView weapon;
        
        [Inject] private ICommandBuffer _commandBuffer;
        [Inject] private IWeaponRepository _weaponRepository;
        
        public WeaponView Weapon => weapon;

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
                    OnAttackEnd();
                    _commandBuffer.CompletePerformingAttack(unitEntity.Uid.Value);
                }).AddTo(gameObject);
                
                
                attackEndTrigger?.AttackStart.Subscribe(_ =>
                {
                    OnAttackBegin();
                    _commandBuffer.PerformAttack(unitEntity.Uid.Value);
                });
            }
        }

        protected virtual void OnDirectionChanged(GameEntity entity, Vector3 dir)
        {
            entity.Position.Value = transform.position;
            _rb.velocity = dir;
            //Debug.Log($"OnDirectionChanged: AnimationKeys.Movement {dir.magnitude}, go: {gameObject.name}, velocity {_rb.velocity}");
            _animator.SetFloat(AnimationKeys.Movement, dir.normalized.magnitude, 0.02f, Time.deltaTime);
        }

        private void OnPerformingAttack(GameEntity entity)
        {
            var weaponId = entity.EquippedWeapon.Value.Id;
            int paramId;
            
            paramId = _weaponRepository.GetWeapon(weaponId).WeaponType == EWeaponType.Melee ? AnimationKeys.Attack : AnimationKeys.RangedAttack;
            
            _animator.SetTrigger(paramId);
        }

        private void OnUnitTriggerEnter(Collider other)
        {
            if (!_damageTrigger.enabled)
                return;
            
            if (LayerMask.GetMask(LayerNames.Weapon) == (LayerMask.GetMask(LayerNames.Weapon) 
                                               | 1 << other.gameObject.layer))
            {
                var weaponHash = other.transform.GetHashCode();
                
                _commandBuffer.TakeDamageByWeapon(weaponHash, transform.GetHashCode());
            }
        }

        protected virtual void OnDead(GameEntity _)
        {
            _rootCollider.enabled = false;
            _damageTrigger.enabled = false;
            _animator.SetTrigger(AnimationKeys.Death);
        }

        protected virtual void OnHitCounterChanged(GameEntity entity, int value)
        {
            //Debug.Log($"OnHitCounterChanged, obj: {gameObject}");
            _animator.SetTrigger(AnimationKeys.TakeDamage);
          
            if (_onHitFx != null)
                _onHitFx.Play();
        }

        protected virtual void OnAttackBegin()
        {}
        
        protected virtual void OnAttackEnd()
        {}
    }
}