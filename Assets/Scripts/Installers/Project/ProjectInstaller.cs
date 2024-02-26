﻿using Db.Level;
using Db.Level.Impl;
using Ecs.Core.SceneLoading.LoadingProcessor.Impls;
using Ecs.Core.SceneLoading.SceneLoadingManager;
using Ecs.Core.SceneLoading.SceneLoadingManager.Impls;
using Game.Data;
using Game.Services.Dao.Impl;
using Game.Services.Inventory;
using Game.Services.Inventory.Impl;
using Game.Services.LevelService.Impl;
using Game.Services.SaveService.Impl;
using Game.Services.TimeProvider;
using Game.Utils;
using UnityEngine;
using Zenject;

namespace Installers.Project
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private LevelSettingsBase levelSettingsBase;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LevelService>().AsSingle();
            Container.BindInterfacesTo<LoadingProcessor>().AsSingle();
            Container.BindInterfacesTo<UnityTimerProvider>().AsSingle();
            Container.Bind<ISceneLoadingManager>().To<SceneLoadingManager>().AsSingle();
            Container.Bind<ILevelSettingsBase>().FromInstance(levelSettingsBase);
            Container.Bind<IPlayerInventoryService>().To<PlayerInventoryService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SaveGameService>().AsSingle();
            
            Container.BindInterfacesTo<LocalStorageDao<GameData>>()
                .AsSingle()
                .WithArguments(SavePathKeys.INVENTORY);
            
            SignalBusInstaller.Install(Container);
        }
    }
}