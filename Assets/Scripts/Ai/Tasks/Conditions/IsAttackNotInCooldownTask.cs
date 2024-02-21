using BehaviorDesigner.Runtime.Tasks;

namespace Ai.Tasks.Conditions
{
    public class IsAttackNotInCooldownTask : FixedConditional
    {
        public override TaskStatus OnUpdate()
        {
            var currentCooldownTime = SelfEntity.Time.Value;

            return currentCooldownTime <= 0 ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}