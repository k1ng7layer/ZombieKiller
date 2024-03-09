using Ecs.Extensions.UidGenerator;
using Ecs.Game.Extensions;
using Ecs.Utils.LinkedEntityRepository;
using Game.Services.ProjectilePoolRepository;
using Game.Utils;
using UnityEngine;

namespace Game.Providers.Projectile.Impl
{
    public class ProjectileProvider : IProjectileProvider
    {
        private readonly IProjectilePoolRepository _projectilePoolRepository;
        private readonly ILinkedEntityRepository _linkedEntityRepository;
        private readonly GameContext _game;

        public ProjectileProvider(
            IProjectilePoolRepository projectilePoolRepository,
            ILinkedEntityRepository linkedEntityRepository,
            GameContext game
        )
        {
            _projectilePoolRepository = projectilePoolRepository;
            _linkedEntityRepository = linkedEntityRepository;
            _game = game;
        }
        
        public GameEntity CreateProjectileWithTrajectory(
            Uid Shooter, 
            Vector3 Origin, 
            Vector3[] Trajectory,
            EProjectileType ProjectileType, 
            float Speed)
        {
            var startPoint = Origin;

            var dir = Trajectory[0] - startPoint;
            
            var rotation = Quaternion.LookRotation(dir);
            var projectileRepository = _projectilePoolRepository.GetPool(ProjectileType);
            var projectileView = projectileRepository.Spawn();
            //var destination = command.Target;
            
            var projectileEntity = _game.CreateProjectile(
                EProjectileType.FireBall,
                Shooter,
                Speed, 
                startPoint, 
                rotation, 
                10f, 
                10f);
            
            projectileEntity.AddDestination(Trajectory[0]);
            projectileView.Link(projectileEntity);
            projectileEntity.AddLink(projectileView);
            
            _linkedEntityRepository.Add(projectileView.transform.GetHashCode(), projectileEntity);
            projectileEntity.IsActive = true;
            
            projectileEntity.AddTrajectory(new TrajectoryInfo(Trajectory, 0));

            return projectileEntity;
        }
    }
}