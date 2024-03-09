using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using Db.Enemies;
using Ecs.Utils.Groups;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;
using UnityEngine;

namespace Game.AI.Tasks.Conditions
{
    [Serializable, NodeMenuItem(TaskNames.CAN_USE_ABILITY_PATH)]
    public class CanUseAbilityConditionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
        
        public override string name => TaskNames.CAN_USE_ABILITY;
    }
    
    public class CanUseAbilityConditionBuilder : ATaskBuilder
    {
        private readonly IEnemyParamsBase _enemyParamsBase;
        private readonly IGameGroupUtils _gameGroupUtils;

        public CanUseAbilityConditionBuilder(IEnemyParamsBase enemyParamsBase, IGameGroupUtils gameGroupUtils)
        {
            _enemyParamsBase = enemyParamsBase;
            _gameGroupUtils = gameGroupUtils;
        }
        
        public override string Name => TaskNames.CAN_USE_ABILITY;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) =>
            builder.Condition(Name,
                () =>
                {
                    var enemyParams = _enemyParamsBase.GetEnemyParams(entity.Enemy.EnemyType);

                    if (enemyParams.Abilities.Count == 0)
                        return false;
                    
                    using var abilityGroup = _gameGroupUtils.GetAbilities(out var abilities);

                    var result = abilities.Count < enemyParams.Abilities.Count;
                    Debug.Log($"CanUseAbilityConditionBuilder: {result}");
                    return abilities.Count < enemyParams.Abilities.Count;

                });
    }
}