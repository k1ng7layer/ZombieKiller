using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using Game.AI;
using Game.AI.Tasks;
using Game.Models.Ai.Utils;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.Models.Ai.Tasks.Utils
{
    [Serializable, NodeMenuItem(TaskNames.SKIP_TICKS_PATH)]
    public class SkipTicksActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public int ticks;

        public override Dictionary<string, object> Values =>
            new()
            {
                { TaskParametersNames.TICKS, ticks }
            };
        
        public override string name => TaskNames.SKIP_TICKS;
    }
    
    public class SkipTicksActionBuilder : ATaskBuilder
    {
        public override string Name => TaskNames.SKIP_TICKS;

        public override void Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues)
        {
            var ticks = (int)taskValues[TaskParametersNames.TICKS];
            builder.SkipTicks("Skip ticks", ticks);
        }
    }
}