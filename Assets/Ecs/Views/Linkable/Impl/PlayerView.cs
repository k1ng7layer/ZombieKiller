using System;
using System.Collections.Generic;
using Ecs.Core.Interfaces;
using Ecs.Utils;
using Game.Utils;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.Utils;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ecs.Views.Linkable.Impl
{
    public class PlayerView : UnitView
    {
        [SerializeField] private ParticleSystem[] levelUpVfx;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Renderer[] _renderers;

        [Inject] private ITimeProvider _timeProvider;
        
        private GameEntity _playerEntity;
        private MaterialPropertyBlock _unitMaterialPropertyBlock;

        private bool _fading;
        private float _flickCooldown;
        private float _colorLerpTime;
        private Color _defaultColor;
        private readonly Dictionary<int, Color> _colors = new();
        
        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            _playerEntity = (GameEntity)entity;
            
            _playerEntity.SubscribeHealth(OnHealthChanged).AddTo(unsubscribe);
            _playerEntity.SubscribeEquippedWeapon(OnEquippedWeaponChanged).AddTo(unsubscribe);
            _playerEntity.SubscribeUnitLevel(OnLevelUp).AddTo(unsubscribe);
            
            _unitMaterialPropertyBlock = new MaterialPropertyBlock();

            _renderers = GetComponentsInChildren<Renderer>();

            foreach (var unitRender in _renderers)
            {
                _colors.Add(unitRender.GetHashCode(), unitRender.material.color);
            }
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
            //Debug.Log($"OnDirectionChanged: {dir}");
            characterController.Move(dir);

            if (dir == Vector3.zero)
            {
                _animator.SetFloat(AnimationKeys.Movement, 0f);
            }
            else
            {
                _animator.SetFloat(AnimationKeys.Movement, dir.normalized.magnitude, 0.02f, Time.deltaTime);
            }
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

        protected override void OnHitCounterChanged(GameEntity entity, int value)
        {
            base.OnHitCounterChanged(entity, value);
            
            if (_flickCooldown > 0 || _colorLerpTime > 0)
                return;
            
            _flickCooldown = 1f;
            _fading = true;
            
            _unitMaterialPropertyBlock.SetColor("_Color", Color.white);
            
            foreach (var renderer in _renderers)
            {
                renderer.SetPropertyBlock(_unitMaterialPropertyBlock);
            }
        }

        private void Update()
        {
            if (_playerEntity != null)
            {
                var transform1 = transform;
                _playerEntity.Position.Value = transform1.position;
                _playerEntity.Rotation.Value = transform1.rotation;
            }
            
            if (_flickCooldown > 0)
            {
                _flickCooldown -= _timeProvider.DeltaTime;
            }

            if (_fading)
            {
                foreach (var playerRenderer in _renderers)
                {
                    var defaultColor = _colors[playerRenderer.GetHashCode()];
                    var color = Color.Lerp(Color.white, defaultColor, _colorLerpTime);
                    _unitMaterialPropertyBlock.SetColor("_Color", color);
                    _colorLerpTime += _timeProvider.DeltaTime * 0.1f;
                    playerRenderer.SetPropertyBlock(_unitMaterialPropertyBlock);
                }

                if (_colorLerpTime >= 1)
                {
                    _colorLerpTime = 0f;
                    _fading = false;
                }
                   
            }
        }
        
    }
}