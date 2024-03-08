using System.Linq;
using Ecs.Commands.Command;
using Ecs.Core.SceneLoading.SceneLoadingManager;
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
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly ILevelService _levelService;
        private readonly ISaveGameService _saveGameService;

        public LoadNextStageSystem(
            ICommandBuffer commandBuffer, 
            ISceneLoadingManager sceneLoadingManager, 
            ILevelService levelService,
            ISaveGameService saveGameService
        ) : base(commandBuffer)
        {
            _sceneLoadingManager = sceneLoadingManager;
            _levelService = levelService;
            _saveGameService = saveGameService;
        }

        protected override void Execute(ref LoadNextStageCommand command)
        {
            var nextLevel = _levelService.GetNextLevel();
            _levelService.SetCurrentLevel(nextLevel);
            var nextLevelName = _levelService.GetLevelSceneName(nextLevel);
            
            _saveGameService.Save();
            _sceneLoadingManager.LoadGameLevel(nextLevelName);
        }
    }
}