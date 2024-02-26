using Ecs.Commands.Command;
using Game.Services.Inventory;
using Game.Services.SaveService;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 3000, nameof(EFeatures.Common))]
    public class SaveGameSystem : ForEachCommandUpdateSystem<SaveGameCommand>
    {
        private readonly ISaveGameService _saveGameService;
        private readonly IPlayerInventoryService _playerInventoryService;
        private readonly GameContext _game;

        public SaveGameSystem(
            ICommandBuffer commandBuffer,
            ISaveGameService saveGameService,
            IPlayerInventoryService playerInventoryService,
            GameContext game
        ) : base(commandBuffer)
        {
            _saveGameService = saveGameService;
            _playerInventoryService = playerInventoryService;
            _game = game;
        }

        protected override void Execute(ref SaveGameCommand command)
        {
            // var player = _game.PlayerEntity;
            //
            // var data = _saveGameService.CurrentGameData;
            // data.Inventory.Items = _playerInventoryService.GetAll().ToList();
            // data.Player.Experience = player.Experience.Value;
            //
            // _saveGameService.Save();
        }
    }
}