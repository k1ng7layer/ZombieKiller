using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Conditions
{
    [Serializable, NodeMenuItem(TaskNames.IS_ATTACKING_PATH)]
    public class IsAttackingConditionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
        
        public override string name => TaskNames.IS_ATTACKING;
    }
    
    public class IsAttackingConditionBuilder : ATaskBuilder
    {
        public override string Name => TaskNames.IS_ATTACKING;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) =>
            builder.Condition(Name,
                () => entity.IsPerformingAttack);
    }
}