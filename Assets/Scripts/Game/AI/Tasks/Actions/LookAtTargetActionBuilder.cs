using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Game.Extensions;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;
using UnityEngine;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.LOOK_AT_TARGET_PATH)]
    public class LookAtTargetActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
        
        public override string name => TaskNames.LOOK_AT_TARGET;
    }
    
    public class LookAtTargetActionBuilder : ATaskBuilder
    {
        private readonly GameContext _game;

        public LookAtTargetActionBuilder(GameContext game)
        {
            _game = game;
        }

        public override string Name => TaskNames.LOOK_AT_TARGET;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {
                var target = _game.GetEntityWithUid(entity.Target.TargetUid);
                var targetPos = target.Position.Value;
                var entityPos = entity.Position.Value;
                var currentRot = entity.Rotation.Value;
                var dir = targetPos - entityPos;
                
                var targetRot = Quaternion.LookRotation(dir.NoY());

                var tt = Quaternion.RotateTowards(currentRot, targetRot, 3f);
                
                Debug.Log($"LookAtTargetActionBuilder: {dir}");
                entity.ReplaceRotation(tt);


                return TaskStatus.Continue;
            });
    }
}