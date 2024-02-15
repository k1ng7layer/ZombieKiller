using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Initialize
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 50, nameof(EFeatures.Initialization))]
    public class GameInitializeSystem : IInitializeSystem
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly GameContext _game;

        public GameInitializeSystem(
            ICommandBuffer commandBuffer,
            GameContext game
        )
        {
            _commandBuffer = commandBuffer;
            _game = game;
        }

        public void Initialize()
        {
            
        }
    }
}