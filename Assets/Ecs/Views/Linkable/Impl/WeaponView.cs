using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.Utils;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public class WeaponView : ObjectView
    {
        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            var weaponEntity = (GameEntity)entity;

            weaponEntity.SubscribeParentTransform(OnWeaponTransformChanged).AddTo(unsubscribe);
        }

        private void OnWeaponTransformChanged(GameEntity _, Transform value)
        {
            var selfTransform = transform;
            
            selfTransform.SetParent(value);
            selfTransform.localPosition = Vector3.zero;
            selfTransform.localRotation = Quaternion.identity;
        }
    }
}