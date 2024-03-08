using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;
using UnityEngine;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.MOVE_TO_TARGET_PATH)]
    public class MoveToTargetActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
        
        public override string name => TaskNames.MOVE_TO_TARGET;
    }
    
    public class MoveToTargetActionBuilder : ATaskBuilder
    {
        private readonly GameContext _game;
    
        public MoveToTargetActionBuilder(GameContext game)
        {
            _game = game;
        }

        public override string Name => TaskNames.MOVE_TO_TARGET;
        
        public override void Fill(BehaviorTreeBuilder builder, 
            GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(Name,
            () =>
            {
                entity.IsMoving = true;
                var target = _game.GetEntityWithUid(entity.Target.TargetUid);
                var dir = entity.Rotation.Value * Vector3.forward;
                entity.ReplaceDestination(target.Position.Value);
               // entity.ReplaceMoveDirection(dir);
                Debug.Log($"MoveToTargetActionBuilder");
                return TaskStatus.Continue;
                
            });
    }
}