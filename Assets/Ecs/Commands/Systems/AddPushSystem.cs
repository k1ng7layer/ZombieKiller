using Ecs.Commands.Command;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 500, nameof(EFeatures.Input))]
    public class AddPushSystem : ForEachCommandUpdateSystem<AddPushCommand>
    {
        private readonly GameContext _game;

        public AddPushSystem(
            ICommandBuffer commandBuffer, 
            GameContext game
        ) : base(commandBuffer)
        {
            _game = game;
        }

        protected override void Execute(ref AddPushCommand command)
        {
            Debug.Log($"AddPushSystem");
            var unit = _game.GetEntityWithUid(command.Unit);
            //unit.IsCanMove = false;
            var moveDir = unit.MoveDirection.Value;
            unit.ReplacePushDirection(command.Direction.normalized);
            unit.ReplacePushForce(command.Force);
        }
    }
}