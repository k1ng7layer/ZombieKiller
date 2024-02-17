using System;
using Db.ProjectileBase;
using Ecs.Views.Linkable.Impl.Projectiles;
using Game.Services.Pools.Projectile;
using Game.Services.Pools.Projectile.Impl;
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
            }
        }

        private void BindProjectilePool(EProjectileType projectileType)
        {
            var parent = new GameObject($"[Pool] Projectile type {projectileType}");
            
            Container.BindMemoryPoolCustomInterface<ProjectileView, ProjectilePool, IProjectilePool>().WithInitialSize(20).WithFactoryArguments(projectileType).FromMethod(container =>
            {

                var projectileBase = container.Resolve<IProjectileBase>();
                var prefab = projectileBase.Get(projectileType);

                var go = container.InstantiatePrefab(prefab, parent.transform);

                return go.GetComponent<ProjectileView>();
            });
        }
    }
}