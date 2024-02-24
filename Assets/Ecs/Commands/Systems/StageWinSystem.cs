using Ecs.Commands.Command;
using Ecs.Utils.Groups;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 900, nameof(EFeatures.Common))]
    public class StageWinSystem : ForEachCommandUpdateSystem<StageWinCommand>
    {
        private readonly IGameGroupUtils _gameGroupUtils;

        public StageWinSystem(
            ICommandBuffer commandBuffer, 
            IGameGroupUtils gameGroupUtils
        ) : base(commandBuffer)
        {
            _gameGroupUtils = gameGroupUtils;
        }

        protected override void Execute(ref StageWinCommand command)
        {
            using var portalsGroup = _gameGroupUtils.GetStagePortals(out var portals, p => !p.IsActive);

            foreach (var portal in portals)
            {
                portal.IsActive = true;
            }
        }
    }
}