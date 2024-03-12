using System;
using Ecs.Utils;
using Game.Utils;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.Utils;
using UniRx;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public class PlayerView : UnitView
    {
        [SerializeField] private ParticleSystem[] levelUpVfx;
        [SerializeField] private CharacterController characterController;
        
        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            var playerEntity = (GameEntity)entity;
            
            playerEntity.SubscribeHealth(OnHealthChanged).AddTo(unsubscribe);
            playerEntity.SubscribeEquippedWeapon(OnEquippedWeaponChanged).AddTo(unsubscribe);
            playerEntity.SubscribeUnitLevel(OnLevelUp).AddTo(unsubscribe);
        }
        
        private void OnHealthChanged(GameEntity entity, float value)
        {
            Debug.Log($"player health changed: {value}");
        }
        
        private void OnEquippedWeaponChanged(GameEntity entity, EquippedWeaponInfo equippedWeaponInfo)
        {
            //var weaponParams = 
        }

        private void OnLevelUp(GameEntity _, int level)
        {
            foreach (var lParticleSystem in levelUpVfx)
            {
                lParticleSystem.Play();
            }
        }

        protected override void OnDirectionChanged(GameEntity entity, Vector3 dir)
        {
            characterController.Move(dir);
            _animator.SetFloat(AnimationKeys.Movement, dir.normalized.magnitude, 0.02f, Time.deltaTime);
        }

        protected override void OnAttackBegin()
        {
            
            Observable.Timer(TimeSpan.FromMilliseconds(30)).Subscribe(_ =>
            {
                characterController.enabled = false;
                _rootCollider.enabled = true;
                _rb.isKinematic = false;
                _rb.AddForce(transform.forward * 24f, ForceMode.Impulse);
            });
            
            Observable.Timer(TimeSpan.FromMilliseconds(650)).Subscribe(_ =>
            {
                // _rootCollider.enabled = false;
                // characterController.enabled = true;
                // _rb.isKinematic = true;
            });
            //_rb.AddForce(transform.forward * 20f, ForceMode.Impulse);
        }

        protected override void OnAttackEnd()
        {
            _rootCollider.enabled = false;
            characterController.enabled = true;
            _rb.isKinematic = true;
        }
    }
}