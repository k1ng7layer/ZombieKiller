using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using Game.AI.Tasks;
using Game.Models.Ai.Utils;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes.Decorators;

namespace Game.Models.Ai.Tasks.Default.TaskParents
{
    [Serializable, NodeMenuItem(TaskNames.REPEATER_ALL_UNTIL_FAILURE_PATH)]
    public class RepeatAllUntilFailureNode : ADecoratorNode
    {
        public override string name => TaskNames.REPEATER_ALL_UNTIL_FAILURE;
    }

    public class RepeatAllUntilFailureBuilder : ATaskParentBuilder
    
    {
        public override string Name => TaskNames.REPEATER_ALL_UNTIL_FAILURE;

        public override void Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues)
            => builder.RepeatAllUntilFailure();
    }
}