using System;
using Db.Prefabs;
using Db.ProjectileBase;
using Ecs.Views.Linkable.Impl;
using Ecs.Views.Linkable.Impl.Projectiles;
using Ecs.Views.Linkable.Impl.Spots;
using Game.Services.ExplosionPoolRepository;
using Game.Services.ExplosionPoolRepository.Impl;
using Game.Services.Pools.Explosion;
using Game.Services.Pools.Explosion.Impl;
using Game.Services.Pools.Projectile;
using Game.Services.Pools.Projectile.Impl;
using Game.Services.Pools.Spot;
using Game.Services.Pools.SwordSlash;
using Game.Services.Pools.SwordSlash.Impl;
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
            Container.Bind<IExplosionPoolRepository>().To<ExplosionPoolRepository>().AsSingle();
            
            foreach (var projectileType in (EProjectileType[])Enum.GetValues(typeof(EProjectileType)))
            {
                if (projectileType == EProjectileType.None)
                    continue;
                
                BindProjectilePool(projectileType);
                BindSpotPool();
                BindSwordSlashPool();

            }

            foreach (var explosionType in (EExplosionType[])Enum.GetValues(typeof(EExplosionType)))
            {
                BindExplosionPool(explosionType);
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

        private void BindExplosionPool(EExplosionType explosionType)
        {
            var parent = new GameObject($"[Pool] Explosion type {explosionType}");
            
            Container.BindMemoryPoolCustomInterface<ExplosionView, ExplosionPool, IExplosionPool>()
                .WithInitialSize(1)
                .WithFactoryArguments(explosionType)
                .FromMethod(container =>
                {

                    var projectileBase = container.Resolve<IPrefabsBase>();
                    var prefab = projectileBase.Get(explosionType.ToString());

                    var go = container.InstantiatePrefab(prefab, parent.transform);

                    return go.GetComponent<ExplosionView>();
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

        private void BindSwordSlashPool()
        {
            var parent = new GameObject($"[Pool] Sword slash");

            Container.BindMemoryPoolCustomInterface<ParticleSystem, SwordSlashPool, ISwordSlashPool>()
                .WithInitialSize(6)
                .FromMethod(container =>
                {
                    var prefabBase = container.Resolve<IPrefabsBase>();
                    
                    var prefab = prefabBase.Get("SwordSlashWhite");

                    var go = container.InstantiatePrefab(prefab, parent.transform);

                    return go.GetComponent<ParticleSystem>();
                });
        }
    }
}