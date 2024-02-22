using BehaviorDesigner.Runtime.Tasks;

namespace Ai.Tasks.Action
{
    public class MoveToPlayerTask : FixedAction
    {
        public override TaskStatus OnUpdate()
        {
            var targetPosition = Game.PlayerEntity.Position.Value;
            SelfEntity.ReplaceDestinationPosition(targetPosition);

            return TaskStatus.Running;
        }
    }
}