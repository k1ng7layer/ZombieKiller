using Ecs.Game.Extensions;
using Ecs.Views.Linkable.Impl;
using Game.Providers.GameFieldProvider;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using Zenject;

namespace Ecs.Game.Systems.Initialize
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 60, nameof(EFeatures.Initialization))]
    public class CameraInitializeSystem : IInitializeSystem
    {
        private readonly DiContainer _diContainer;
        private readonly GameContext _game;
        private readonly IGameFieldProvider _gameFieldProvider;

        public CameraInitializeSystem(
            DiContainer diContainer,
            GameContext game,
            IGameFieldProvider gameFieldProvider
        )
        {
            _diContainer = diContainer;
            _game = game;
            _gameFieldProvider = gameFieldProvider;
        }
        
        public void Initialize()
        {
            var physicalCameraView = _gameFieldProvider.GameField.PhysicalCameraView;
            var physicalCamera = _game.CreateEntity();
            physicalCamera.IsCamera = true;
            
            _diContainer.Inject(physicalCameraView);
            physicalCameraView.Link(physicalCamera);

            var virtualCameraEntity = _game.CreateEntity();
            var virtualCameraView = _gameFieldProvider.GameField.VirtualCameraView;
            virtualCameraEntity.IsVirtualCamera = true;
            _diContainer.Inject(virtualCameraView);
            virtualCameraView.Link(physicalCamera);
        }
    }
}