using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.Models.Ai.Tasks.Default.TaskParents
{
    [Serializable, NodeMenuItem(DefaultTaskNames.ASYNCPARALLEL)]
    public class SuccessWithChanceNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
    }
    
    public class AsyncParallelBuilder : ATaskParentBuilder
    {
        public override string Name => DefaultTaskNames.ASYNCPARALLEL;

        public override void Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues)
            => builder.AsyncParallel();
    }
}