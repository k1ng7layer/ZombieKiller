using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;
using UnityEngine;

namespace Game.AI.Tasks.Conditions
{
    [Serializable, NodeMenuItem(TaskNames.HAS_ACTIVE_ABILITY_PATH)]
    public class HasActiveAbilityConditionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
        
        public override string name => TaskNames.HAS_ACTIVE_ABILITY;
    }
    
    public class HasActiveAbilityConditionBuilder : ATaskBuilder
    {
        public override string Name => TaskNames.HAS_ACTIVE_ABILITY;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) =>
            builder.Condition(Name,
                () =>
                {
                    Debug.Log($"HasActiveAbilityConditionBuilder: {entity.HasActiveAbility}");
                    return entity.HasActiveAbility;
                });
    }
}