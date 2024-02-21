using BehaviorDesigner.Runtime.Tasks;
using Ecs.Commands;

namespace Ai.Tasks.Action
{
    public class AttackTask : FixedAction
    {
        public override TaskStatus OnUpdate()
        {
            CommandBuffer.PerformAttack(SharedUid.Value); //TODO: add new command or change current system of attack for enemy use too
            
            return TaskStatus.Success;
        }
    }
}