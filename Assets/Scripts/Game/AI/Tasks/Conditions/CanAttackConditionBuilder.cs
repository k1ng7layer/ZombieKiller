using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;
using UnityEngine;

namespace Game.AI.Tasks.Conditions
{
    [Serializable, NodeMenuItem(TaskNames.CAN_ATTACK_PATH)]
    public class CanAttackConditionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
        
        public override string name => TaskNames.CAN_ATTACK;
    }
    
    public class CanAttackConditionBuilder : ATaskBuilder
    {
        public override string Name => TaskNames.CAN_ATTACK;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) =>
            builder.Condition(Name,
                () =>
                {
                    var result = !entity.IsPerformingAttack && entity.HasEquippedWeapon && entity.AttackCooldown.Value <= 0;
                    Debug.Log($"CanAttackConditionBuilder: {result}");
                    return result;
                });
    }
}