using System;
using Game.Services.Pools.SwordSlash;
using UniRx;
using UnityEngine;
using Zenject;

namespace Ecs.Views.Linkable.Impl
{
    public class SwordView : WeaponView
    {
        [SerializeField] private Vector3 _fxRotation;
        [SerializeField] private Vector3 _fxPosition;
        [SerializeField] private ParticleSystem _weaponFx;
        
        [Inject] private ISwordSlashPool _swordSlashPool;
        
        protected override void OnWeaponAttackAdded(GameEntity _)
        {
            base.OnWeaponAttackAdded(_);
            
            if (_weaponFx == null)
                return;
                
            var fx = _swordSlashPool.Spawn();
            var fxTransform = fx.transform;
            
            fxTransform.position = transform.position;
            fxTransform.rotation = Quaternion.Euler(_fxRotation);
            fx.Play();

            Observable.Timer(TimeSpan.FromMilliseconds(1000)).Subscribe(_ =>
            {
                _swordSlashPool.Despawn(fx);
            });
        }
    }
}