using Ecs.Commands.Command;
using Ecs.Utils.LinkedEntityRepository;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 900, nameof(EFeatures.Common))]
    public class TeleportPlayerSystem : ForEachCommandUpdateSystem<TeleportPlayerCommand>
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly ILinkedEntityRepository _linkedEntityRepository;

        public TeleportPlayerSystem(
            ICommandBuffer commandBuffer, 
            ILinkedEntityRepository linkedEntityRepository
        ) : base(commandBuffer)
        {
            _commandBuffer = commandBuffer;
            _linkedEntityRepository = linkedEntityRepository;
        }

        protected override void Execute(ref TeleportPlayerCommand command)
        {
            var portalHash = command.PortalHash;

            var portal = _linkedEntityRepository.Get(portalHash);

            if (portal.Portal.PortalDestination == EPortalDestination.NextLevel && portal.IsActive)
            {
                portal.IsActive = false;
                _commandBuffer.LoadNextStage();
            }
            
            if (portal.Portal.PortalDestination == EPortalDestination.Shelter)
                _commandBuffer.LoadShelter();
        }
    }
}