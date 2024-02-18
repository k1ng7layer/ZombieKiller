using Ecs.Utils;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.Utils;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public class PlayerView : UnitView
    {
        [SerializeField] private GameObject weaponRoot;

        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            var playerEntity = (GameEntity)entity;
            
            playerEntity.SubscribeHealth(OnHealthChanged).AddTo(unsubscribe);
            playerEntity.SubscribeEquippedWeapon(OnEquippedWeaponChanged).AddTo(unsubscribe);
            
            playerEntity.ReplaceWeaponRoot(weaponRoot.transform);
        }
        
        private void OnHealthChanged(GameEntity entity, float value)
        {
            Debug.Log($"player health changed: {value}");
        }
        
        private void OnEquippedWeaponChanged(GameEntity entity, EquippedWeaponInfo equippedWeaponInfo)
        {
            //var weaponParams = 
        }
    }
}