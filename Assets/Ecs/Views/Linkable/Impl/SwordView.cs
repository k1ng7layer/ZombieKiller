using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public class SwordView : WeaponView
    {
        [SerializeField] private ParticleSystem _weaponFx;
        
        protected override void OnWeaponAttackAdded(GameEntity _)
        {
            base.OnWeaponAttackAdded(_);
            
            if (_weaponFx == null)
                return;
            
            _weaponFx.Play();
        }
    }
}