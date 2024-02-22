using Ecs.Commands.Command;
using Ecs.Core.SceneLoading.SceneLoadingManager;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 950, nameof(EFeatures.Common))]
    public class LoadShelterSystem : ForEachCommandUpdateSystem<LoadShelterCommand>
    {
        private readonly ISceneLoadingManager _sceneLoadingManager;

        public LoadShelterSystem(
            ICommandBuffer commandBuffer, 
            ISceneLoadingManager sceneLoadingManager
        ) : base(commandBuffer)
        {
            _sceneLoadingManager = sceneLoadingManager;
        }

        protected override void Execute(ref LoadShelterCommand command)
        {
            _sceneLoadingManager.LoadGameLevel(ELevelName.SHELTER.ToString());
        }
    }
}