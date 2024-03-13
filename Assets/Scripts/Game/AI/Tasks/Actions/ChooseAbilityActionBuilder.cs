using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Db.Enemies;
using Ecs.Utils.Groups;
using Game.Utils;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.CHOOSE_ABILITY_PATH)]
    public class ChooseAbilityActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
        
        public override string name => TaskNames.CHOOSE_ABILITY;
    }
    
    public class ChooseAbilityActionBuilder : ATaskBuilder
    {
        private readonly IEnemyParamsBase _enemyParamsBase;
        private readonly IGameGroupUtils _gameGroupUtils;

        public ChooseAbilityActionBuilder(
            IEnemyParamsBase enemyParamsBase, 
            IGameGroupUtils gameGroupUtils
        )
        {
            _enemyParamsBase = enemyParamsBase;
            _gameGroupUtils = gameGroupUtils;
        }
        
        public override string Name => TaskNames.CHOOSE_ABILITY;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {

                var enemyParams = _enemyParamsBase.GetEnemyParams(entity.Enemy.EnemyType);

                foreach (var abilityType in enemyParams.Abilities)
                {
                    if (CanCast(abilityType))
                    {
                        entity.ReplaceActiveAbility(abilityType);
                        break;
                    }
                }

                return TaskStatus.Success;
                
            });
        
        private bool CanCast(EAbilityType abilityType)
        {
            using var abilityGroup = _gameGroupUtils.GetAbilities(out var abilities);

            foreach (var ability in abilities)
            {
                if (ability.Ability.AbilityType == abilityType)
                    return false;
            }

            return true;
        }
    }
}