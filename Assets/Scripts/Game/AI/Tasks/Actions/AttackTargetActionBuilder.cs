using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Ecs.Commands;
using GraphProcessor;
using JCMG.EntitasRedux.Commands;
using Plugins.NgpBehaviourTreeDesigner.Nodes;
using UnityEngine;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.PERFORM_ATTACK_PATH)]
    public class AttackTargetActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
        
        public override string name => TaskNames.PERFORM_ATTACK;
    }
    
    public class AttackTargetActionBuilder : ATaskBuilder
    {
        private readonly ICommandBuffer _commandBuffer;

        public AttackTargetActionBuilder(ICommandBuffer commandBuffer)
        {
            _commandBuffer = commandBuffer;
        }

        public override string Name => TaskNames.PERFORM_ATTACK;

        public override void
            Fill(BehaviorTreeBuilder builder, 
                GameEntity entity, 
                Dictionary<string, object> taskValues) => builder.Do(
            Name, () =>
            {
                Debug.Log($"AttackTargetActionBuilder");
                _commandBuffer.StartPerformingAttack(entity.Uid.Value);

                return TaskStatus.Success;
                
            });
    }
}