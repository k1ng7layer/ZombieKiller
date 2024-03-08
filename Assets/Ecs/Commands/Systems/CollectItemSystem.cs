using Ecs.Commands.Command;
using Game.Services.Inventory;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 920, nameof(EFeatures.Common))]
    public class CollectItemSystem : ForEachCommandUpdateSystem<CollectItemCommand>
    {
        private readonly IPlayerInventoryService _playerInventoryService;

        public CollectItemSystem(
            ICommandBuffer commandBuffer,
            IPlayerInventoryService playerInventoryService
        ) : base(commandBuffer)
        {
            _playerInventoryService = playerInventoryService;
        }

        protected override void Execute(ref CollectItemCommand command)
        {
            _playerInventoryService.TryAdd(command.ItemId);
        }
    }
}