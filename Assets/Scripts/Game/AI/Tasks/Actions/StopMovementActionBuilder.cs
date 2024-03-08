using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;
using UnityEngine;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.STOP_MOVEMENT_PATH)]
    public class StopMovementActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
        
        public override string name => TaskNames.STOP_MOVEMENT;
    }
    
    public class StopMovementActionBuilder : ATaskBuilder
    {
        public override string Name => TaskNames.STOP_MOVEMENT;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {
                entity.IsMoving = false;
                entity.ReplaceMoveDirection(Vector3.zero);
                entity.ReplaceDestination(entity.Position.Value);
                entity.IsMoving = false;
                return TaskStatus.Success;
            });
    }
}