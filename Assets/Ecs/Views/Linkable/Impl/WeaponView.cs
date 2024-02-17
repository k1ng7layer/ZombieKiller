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
            transform.SetParent(value);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}