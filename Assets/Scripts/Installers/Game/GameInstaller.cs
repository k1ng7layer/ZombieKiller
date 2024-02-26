using Ecs.Utils.LinkedEntityRepository.Impl;
using Ecs.Utils.SpawnService.Impl;
using Game.Providers.PowerUpProvider.Impl;
using Game.Providers.RandomProvider.Impl;
using Game.Services.InputService.Impl;
using Game.Services.PrefabPoolService.Impl;
using Game.Ui.Inventory;
using Game.Ui.PlayerStats.LevelUp;
using Game.Ui.Windows;
using Game.Utils.Raycast.Impl;
using Zenject;

namespace Installers.Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            DeclareSignals();
            BindWindows();
            BindServices();
        }

        private void DeclareSignals()
        {
            Container.DeclareSignal<GameHudWindow>();
            Container.DeclareSignal<LevelUpWindow>();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<GameHudWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelUpWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerBagInventoryWindow>().AsSingle();
        }
        
        private void BindServices()
        {
            Container.BindInterfacesTo<SpawnService>().AsSingle();
            Container.BindInterfacesTo<LinkedEntityRepository>().AsSingle();
            Container.BindInterfacesTo<PrefabPoolService>().AsSingle();
            Container.BindInterfacesTo<UnityInputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<RayCastProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<SystemRandomProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<RandomPowerUpIdProvider>().AsSingle();
        }
    }
}