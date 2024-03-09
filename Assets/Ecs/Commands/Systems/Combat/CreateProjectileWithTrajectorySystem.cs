using Ecs.Commands.Command.Combat;
using Ecs.Game.Extensions;
using Ecs.Utils.LinkedEntityRepository;
using Game.Services.ProjectilePoolRepository;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Commands.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 230, nameof(EFeatures.Combat))]
    public class CreateProjectileWithTrajectorySystem : ForEachCommandUpdateSystem<CreateProjectileWithTrajectoryCommand>
    {
        private readonly IProjectilePoolRepository _projectilePoolRepository;
        private readonly ILinkedEntityRepository _linkedEntityRepository;
        private readonly GameContext _game;

        public CreateProjectileWithTrajectorySystem(
            ICommandBuffer commandBuffer,
            IProjectilePoolRepository projectilePoolRepository,
            ILinkedEntityRepository linkedEntityRepository,
            GameContext game
        ) : base(commandBuffer)
        {
            _projectilePoolRepository = projectilePoolRepository;
            _linkedEntityRepository = linkedEntityRepository;
            _game = game;
        }

        protected override void Execute(ref CreateProjectileWithTrajectoryCommand command)
        {
            var startPoint = command.Origin;

            var dir = command.Trajectory[0] - startPoint;
            
            var rotation = Quaternion.LookRotation(dir);
            var projectileRepository = _projectilePoolRepository.GetPool(command.ProjectileType);
            var projectileView = projectileRepository.Spawn();
            //var destination = command.Target;
            
            var projectileEntity = _game.CreateProjectile(
                EProjectileType.FireBall,
                command.Shooter,
                command.Speed, 
                startPoint, 
                rotation, 
                10f, 
                10f);
            
            projectileEntity.AddDestination(command.Trajectory[0]);
            projectileView.Link(projectileEntity);
            projectileEntity.AddLink(projectileView);
            
            _linkedEntityRepository.Add(projectileView.transform.GetHashCode(), projectileEntity);
            projectileEntity.IsActive = true;
            
            projectileEntity.AddTrajectory(new TrajectoryInfo(command.Trajectory, 0));
        }
    }
}