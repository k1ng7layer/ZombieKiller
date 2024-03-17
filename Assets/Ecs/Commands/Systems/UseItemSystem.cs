using Db.Items;
using Ecs.Commands.Command;
using Game.Services.Inventory;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 500, nameof(EFeatures.Common))]
    public class UseItemSystem : ForEachCommandUpdateSystem<UseItemCommand>
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly IItemsBase _itemsBase;
        private readonly IPlayerInventoryService _playerInventoryService;

        public UseItemSystem(
            ICommandBuffer commandBuffer, 
            IItemsBase itemsBase,
            IPlayerInventoryService playerInventoryService
        ) : base(commandBuffer)
        {
            _commandBuffer = commandBuffer;
            _itemsBase = itemsBase;
            _playerInventoryService = playerInventoryService;
        }

        protected override void Execute(ref UseItemCommand command)
        {
            var itemType = _itemsBase.GetItemType(command.ItemId);
            
           if (itemType == EItemType.Potion)
               _commandBuffer.UsePotion(command.ItemId);

           _playerInventoryService.TryRemove(command.ItemId);
        }
    }
}