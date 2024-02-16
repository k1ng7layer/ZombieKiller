using Ecs.Commands.Command.Combat;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 1500, nameof(EFeatures.Combat))]
    public class PerformAttackCleanupSystem : ForEachCommandUpdateSystem<PerformAttackCommand>
    {
        public PerformAttackCleanupSystem(ICommandBuffer commandBuffer) : base(commandBuffer)
        {
        }

        protected override bool CleanUp => true;

        protected override void Execute(ref PerformAttackCommand command)
        { }
    }
}