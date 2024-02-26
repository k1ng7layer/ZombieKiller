using System.Linq;
using Ecs.Commands.Command;
using Ecs.Core.SceneLoading.SceneLoadingManager;
using Game.Services.Inventory;
using Game.Services.LevelService;
using Game.Services.SaveService;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 950, nameof(EFeatures.Common))]
    public class LoadNextStageSystem : ForEachCommandUpdateSystem<LoadNextStageCommand>
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly ILevelService _levelService;
        private readonly ISaveGameService _saveGameService;
        private readonly IPlayerInventoryService _playerInventoryService;
        private readonly GameContext _game;

        public LoadNextStageSystem(
            ICommandBuffer commandBuffer, 
            ISceneLoadingManager sceneLoadingManager, 
            ILevelService levelService,
            ISaveGameService saveGameService,
            IPlayerInventoryService playerInventoryService,
            GameContext game
        ) : base(commandBuffer)
        {
            _commandBuffer = commandBuffer;
            _sceneLoadingManager = sceneLoadingManager;
            _levelService = levelService;
            _saveGameService = saveGameService;
            _playerInventoryService = playerInventoryService;
            _game = game;
        }

        protected override void Execute(ref LoadNextStageCommand command)
        {
            var nextLevel = _levelService.GetNextLevel();
            _levelService.SetCurrentLevel(nextLevel);
            var nextLevelName = _levelService.GetLevelSceneName(nextLevel);
            
         
            var player = _game.PlayerEntity;
            
            var data = _saveGameService.CurrentGameData;
            data.Inventory.Items = _playerInventoryService.GetAll().ToList();
            data.Player.Experience = player.Experience.Value;
            
            _saveGameService.Save();
            
            _sceneLoadingManager.LoadGameLevel(nextLevelName);
        }
    }
}