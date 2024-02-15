using Cinemachine;
using Game.Utils;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.Utils;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl.Camera
{
    public class VirtualCameraView : ObjectView
    {
        [SerializeField] private CinemachineVirtualCamera _tpsCamera;
        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            var selfEntity = (GameEntity)entity;

            selfEntity.SubscribeCameraMode(OnCameraModeChanged).AddTo(unsubscribe);
        }

        private void OnCameraModeChanged(GameEntity entity, ECameraMode cameraMode)
        {
            _tpsCamera.gameObject.SetActive(cameraMode == ECameraMode.TPS);
        }
    }
}