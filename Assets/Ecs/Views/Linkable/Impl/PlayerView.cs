using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.Utils;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public class PlayerView : ObjectView
    {
        [SerializeField] private Rigidbody _rb;

        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            var playerEntity = (GameEntity)entity;
            
            playerEntity.SubscribeMoveDirection(OnDirectionChanged).AddTo(unsubscribe);
        }

        private void OnDirectionChanged(GameEntity entity, Vector3 dir)
        {
            _rb.velocity = dir;
        }
    }
}