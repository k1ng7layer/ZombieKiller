using Ecs.Commands.Command.Combat;
using Ecs.Utils.LinkedEntityRepository;
using Ecs.Views.Linkable.Impl.Projectiles;
using Game.Services.ProjectilePoolRepository;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Commands.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 1000, nameof(EFeatures.Combat))]
    public class DestroyProjectileSystem : ForEachCommandUpdateSystem<DestroyProjectileCommand>
    {
        private readonly ILinkedEntityRepository _linkedEntityRepository;
        private readonly IProjectilePoolRepository _projectilePoolRepository;

        public DestroyProjectileSystem(
            ICommandBuffer commandBuffer, 
            ILinkedEntityRepository linkedEntityRepository,
            IProjectilePoolRepository projectilePoolRepository
        ) : base(commandBuffer)
        {
            _linkedEntityRepository = linkedEntityRepository;
            _projectilePoolRepository = projectilePoolRepository;
        }

        protected override void Execute(ref DestroyProjectileCommand command)
        {
            if (!_linkedEntityRepository.Contains(command.ProjectileHash))
                return;
            
            var projectileEntity = _linkedEntityRepository.Get(command.ProjectileHash);
            _linkedEntityRepository.TryDelete(command.ProjectileHash);
            var view = (ProjectileView)projectileEntity.Link.View;
            var projectilePool = _projectilePoolRepository.GetPool(projectileEntity.Projectile.ProjectileType);
            
            Debug.Log($"Projectile despawn: {view.transform.GetHashCode()}");
            projectileEntity.IsDead = true;
            projectileEntity.IsDestroyed = true;
            projectilePool.Despawn(view);
        }
    }
}