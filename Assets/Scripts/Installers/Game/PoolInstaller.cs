using System;
using Db.Prefabs;
using Db.ProjectileBase;
using Ecs.Views.Linkable.Impl;
using Ecs.Views.Linkable.Impl.Projectiles;
using Game.Services.Pools.Projectile;
using Game.Services.Pools.Projectile.Impl;
using Game.Services.Pools.Spot;
using Game.Services.ProjectilePoolRepository;
using Game.Services.ProjectilePoolRepository.Impl;
using Game.Utils;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    public class PoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IProjectilePoolRepository>().To<ProjectilePoolRepository>().AsSingle();
            
            foreach (var projectileType in (EProjectileType[])Enum.GetValues(typeof(EProjectileType)))
            {
                if (projectileType == EProjectileType.None)
                    continue;
                
                BindProjectilePool(projectileType);
                BindSpotPool();

            }
        }

        private void BindProjectilePool(EProjectileType projectileType)
        {
            var parent = new GameObject($"[Pool] Projectile type {projectileType}");
            
            Container.BindMemoryPoolCustomInterface<ProjectileView, ProjectilePool, IProjectilePool>()
                .WithInitialSize(20)
                .WithFactoryArguments(projectileType)
                .FromMethod(container =>
            {

                var projectileBase = container.Resolve<IProjectileBase>();
                var prefab = projectileBase.Get(projectileType);

                var go = container.InstantiatePrefab(prefab, parent.transform);

                return go.GetComponent<ProjectileView>();
            });
        }

        private void BindSpotPool()
        {
            var parent = new GameObject($"[Pool] Spot");

            Container.BindMemoryPoolCustomInterface<SpotView, SpotPool, ISpotPool>()
                .WithInitialSize(20)
                .FromMethod(container =>
                {
                    var prefabBase = container.Resolve<IPrefabsBase>();
                    
                    var prefab = prefabBase.Get("InteractiveSpot");

                    var go = container.InstantiatePrefab(prefab, parent.transform);

                    return go.GetComponent<SpotView>();
                });
        }
    }
}