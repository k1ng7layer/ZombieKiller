using BehaviorDesigner.Runtime.Tasks;

namespace Ai.Tasks.Conditions
{
    public class IsEnemyDeadTask : FixedConditional
    {
        public override TaskStatus OnUpdate()
        {
            return SelfEntity.IsDead ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}