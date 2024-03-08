using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;

namespace Game.Models.Ai.Tasks.Default.TaskParents
{
    public class ParallelBuilder : ATaskParentBuilder
    {
        public override string Name => DefaultTaskNames.PARALLEL;
        public override void Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues)
            => builder.Parallel();
    }
}