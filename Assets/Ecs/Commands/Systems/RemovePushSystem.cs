using Ecs.Commands.Command;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 100, nameof(EFeatures.Input))]
    public class RemovePushSystem : ForEachCommandUpdateSystem<RemovePushCommand>
    {
        private readonly GameContext _game;

        public RemovePushSystem(
            ICommandBuffer commandBuffer, 
            GameContext game) : base(commandBuffer)
        {
            _game = game;
        }

        protected override void Execute(ref RemovePushCommand command)
        {
            // var unit = _game.GetEntityWithUid(command.Unit);
            // //unit.CharacterController.Value.Move(Vector3.zero);
            // unit.ReplacePushDirection(Vector3.zero);
            // unit.PushDirection.Value = Vector3.zero;
            // unit.ReplacePushForce(0.01f);
            //
            // //unit.PushForce.Value = 0;
            // unit.RemovePushForce();
            // unit.RemovePushDirection();
        }
    }
}