using Game.Providers.CameraProvider;
using Game.Providers.CameraProvider.Impl;
using Game.Providers.GameFieldProvider;
using Game.Providers.GameFieldProvider.Impl;
using Game.Utils;
using UnityEngine;
using Zenject;

namespace Installers.Level
{
    public class LevelInstaller : MonoInstaller
    {
        public Camera GameCamera;
        public GameField GameField;

        public override void InstallBindings()
        {
            var fieldProvider = new GameFieldProvider
            {
                GameField = GameField
            };

            Container.Bind<IGameFieldProvider>().FromInstance(fieldProvider).AsSingle();
            Container.Bind<ICameraProvider>().FromInstance(new SceneCameraProvider(GameCamera)).AsSingle();
        }
    }
}