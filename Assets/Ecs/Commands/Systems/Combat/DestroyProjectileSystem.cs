using Ecs.Commands.Command.Combat;
using Ecs.Utils.LinkedEntityRepository;
using Ecs.Views.Linkable.Impl.Projectiles;
using Game.Services.ProjectilePoolRepository;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 1000, nameof(EFeatures.Combat))]
    public class DestroyProjectileSystem : ForEachCommandUpdateSystem<DestroyProjectileCommand>
    {
        private readonly ILinkedEntityRepository _linkedEntityRepository;
        private readonly IProjectilePoolRepository _projectilePoolRepository;
        private readonly GameContext _game;

        public DestroyProjectileSystem(
            ICommandBuffer commandBuffer, 
            ILinkedEntityRepository linkedEntityRepository,
            IProjectilePoolRepository projectilePoolRepository,
            GameContext game
        ) : base(commandBuffer)
        {
            _linkedEntityRepository = linkedEntityRepository;
            _projectilePoolRepository = projectilePoolRepository;
            _game = game;
        }

        protected override void Execute(ref DestroyProjectileCommand command)
        {
            var projectileEntity = _linkedEntityRepository.Get(command.ProjectileHash);
            
            var hasTarget = _linkedEntityRepository.TryGet(command.TargetHash, out var targetEntity);
            var view = (ProjectileView)projectileEntity.Link.View;
            var projectilePool = _projectilePoolRepository.GetPool(projectileEntity.Projectile.ProjectileType);
            
            if (!hasTarget)
            {
                projectileEntity.IsDead = true;
                projectileEntity.IsDestroyed = true;
                projectilePool.Despawn(view);
                
                return;
            }
            
            var projectileOwner = _game.GetEntityWithUid(projectileEntity.Owner.Value);
            
            if (projectileOwner.Uid.Value == targetEntity.Uid.Value)
                return;
            
            projectileEntity.IsDead = true;
            projectileEntity.IsDestroyed = true;
            
            projectilePool.Despawn(view);
        }
    }
}