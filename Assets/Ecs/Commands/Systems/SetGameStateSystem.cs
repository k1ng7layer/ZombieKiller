using Ecs.Commands.Command;
using Ecs.Core.Interfaces;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 1000, nameof(EFeatures.Common))]
    public class SetGameStateSystem : ForEachCommandUpdateSystem<SetGameStateCommand>
    {
        private readonly ITimeProvider _timeProvider;

        public SetGameStateSystem(ICommandBuffer commandBuffer, ITimeProvider timeProvider) : base(commandBuffer)
        {
            _timeProvider = timeProvider;
        }

        protected override void Execute(ref SetGameStateCommand command)
        {
            switch (command.GameState)
            {
                case EGameState.Game:
                    _timeProvider.TimeScale = 1;
                    break;
                case EGameState.Pause:
                    _timeProvider.TimeScale = 0;
                    break;
            }
        }
    }
}