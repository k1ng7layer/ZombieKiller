using Ecs.Commands.Command;
using Ecs.Core.SceneLoading.SceneLoadingManager;
using Game.Services.LevelService;
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

        public LoadNextStageSystem(
            ICommandBuffer commandBuffer, 
            ISceneLoadingManager sceneLoadingManager, 
            ILevelService levelService
        ) : base(commandBuffer)
        {
            _sceneLoadingManager = sceneLoadingManager;
            _levelService = levelService;
        }

        protected override void Execute(ref LoadNextStageCommand command)
        {
            var nextLevel = _levelService.GetNextLevel();
            _levelService.SetCurrentLevel(nextLevel);
            var nextLevelName = _levelService.GetLevelSceneName(nextLevel);
            
            _sceneLoadingManager.LoadGameLevel(nextLevelName);
        }
    }
}