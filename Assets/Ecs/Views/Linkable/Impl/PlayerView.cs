using Ecs.Utils;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.Utils;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public class PlayerView : UnitView
    {
        [SerializeField] private ParticleSystem[] levelUpVfx;
        
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
    }
}