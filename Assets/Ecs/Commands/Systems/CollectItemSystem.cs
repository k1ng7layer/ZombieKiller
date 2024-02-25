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
        private readonly GameContext _game;
        private readonly IPlayerInventoryService _playerInventoryService;

        public CollectItemSystem(
            ICommandBuffer commandBuffer, 
            GameContext game,
            IPlayerInventoryService playerInventoryService
        ) : base(commandBuffer)
        {
            _game = game;
            _playerInventoryService = playerInventoryService;
        }

        protected override void Execute(ref CollectItemCommand command)
        {
            
        }
    }
}