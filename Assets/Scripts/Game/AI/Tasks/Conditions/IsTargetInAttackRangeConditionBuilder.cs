using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;
using UnityEngine;

namespace Game.AI.Tasks.Conditions
{
    [Serializable, NodeMenuItem(TaskNames.IS_TARGET_IN_ATTACK_RANGE_PATH)]
    public class IsTargetInAttackRangeConditionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
        
        public override string name => TaskNames.IS_TARGET_IN_ATTACK_RANGE;
    }
    
    public class IsTargetInAttackRangeConditionBuilder : ATaskBuilder
    {
        private readonly GameContext _game;

        public IsTargetInAttackRangeConditionBuilder(GameContext game)
        {
            _game = game;
        }
        
        public override string Name => TaskNames.IS_TARGET_IN_ATTACK_RANGE;
        
        public override void Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Condition(Name,
            () =>
            {
                var target = _game.GetEntityWithUid(entity.Target.TargetUid);
                var dist2 = (target.Position.Value - entity.Position.Value).sqrMagnitude;
                var range =  entity.AttackRange.Value;
                Debug.Log(
                    $"IsTargetInAttackRangeConditionBuilder, dist2: {(target.Position.Value - entity.Position.Value).magnitude}, result: {dist2 <= range * range}");
                return dist2 <= range * range;
                
            });
    }
}