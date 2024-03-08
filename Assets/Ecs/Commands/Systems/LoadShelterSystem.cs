using Ecs.Commands.Command;
using Ecs.Core.SceneLoading.SceneLoadingManager;
using Game.Services.SaveService;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 950, nameof(EFeatures.Common))]
    public class LoadShelterSystem : ForEachCommandUpdateSystem<LoadShelterCommand>
    {
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly ISaveGameService _saveGameService;

        public LoadShelterSystem(
            ICommandBuffer commandBuffer, 
            ISceneLoadingManager sceneLoadingManager,
            ISaveGameService saveGameService
        ) : base(commandBuffer)
        {
            _sceneLoadingManager = sceneLoadingManager;
            _saveGameService = saveGameService;
        }

        protected override void Execute(ref LoadShelterCommand command)
        {
            _saveGameService.Save();
            _sceneLoadingManager.LoadGameLevel(ELevelName.SHELTER.ToString());
        }
    }
}