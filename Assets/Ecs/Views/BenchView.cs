using Ecs.Commands;
using Ecs.Views.Linkable.Impl;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using JCMG.EntitasRedux.Core.Utils;
using UnityEngine;
using Zenject;

namespace Ecs.Views
{
    public class BenchView : ObjectView
    {
        [SerializeField] private Transform _startStandToSit;
        [SerializeField] private Transform _sitToStand;
        [SerializeField] private Collider _benchCollider;

        [Inject] private ICommandBuffer _commandBuffer;
        private GameEntity _benchEntity;

        public Transform StartStandToSit => _startStandToSit;
        public Transform SitToStand => _sitToStand;

        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            _benchEntity = (GameEntity)entity;
            _benchEntity.SubscribeActiveRemoved(OnActiveRemoved).AddTo(unsubscribe);
            _benchEntity.SubscribeActive(OnActiveAdded).AddTo(unsubscribe);
        }
        
        private void OnActiveRemoved(GameEntity player)
        {
            _benchCollider.enabled = false;
        }
        
        private void OnActiveAdded(GameEntity player)
        {
            _benchCollider.enabled = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_benchEntity != null)
                {
                    _commandBuffer.SitDownOnBench(_benchEntity.Uid.Value);
                }
            }
        }
    }
}