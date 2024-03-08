using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.Utils;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl.Collectable
{
    public class CollectableView : ObjectView
    {
        [SerializeField] private Rigidbody rb;
        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            // rb.isKinematic = true;
            // rb.useGravity = false;
            
            var collectableEntity = (GameEntity)entity;

            collectableEntity.SubscribeMoveDirectionRemoved(OnMoveDirRemoved).AddTo(unsubscribe);
            //collectableEntity.SubscribeMoveDirection(OnMoveDirectionChanged).AddTo(unsubscribe);
        }

        private void OnMoveDirRemoved(GameEntity _)
        {
            // rb.isKinematic = false;
            // rb.useGravity = true;
        }
    }
}