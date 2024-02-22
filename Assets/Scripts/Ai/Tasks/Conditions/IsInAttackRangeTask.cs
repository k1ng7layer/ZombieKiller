using BehaviorDesigner.Runtime.Tasks;

namespace Ai.Tasks.Conditions
{
    public class IsInAttackRangeTask : FixedConditional
    {
        public override TaskStatus OnUpdate()
        {
            var position = SelfEntity.Position.Value;
            var targetPosition = Game.PlayerEntity.Position.Value;
            var attackRange = SelfEntity.AttackRange.Value;
            var distanceSqr = (targetPosition - position).sqrMagnitude;

            return distanceSqr <= attackRange * attackRange ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}