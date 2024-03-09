using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Db.Enemies;
using Ecs.Utils.Groups;
using Game.Services.Ai;
using Game.Services.Ai.Abilities;
using Game.Utils;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.USE_ABILITY_PATH)]
    public class UseAbilityActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
        
        public override string name => TaskNames.USE_ABILITY;
    }
    
    public class UseAbilityActionBuilder : ATaskBuilder
    {
        private readonly IEnemyParamsBase _enemyParamsBase;
        private readonly IAiAbilityService _aiAbilityService;
        private readonly IGameGroupUtils _gameGroupUtils;

        public UseAbilityActionBuilder(
            IEnemyParamsBase enemyParamsBase,
            IAiAbilityService aiAbilityService,
            IGameGroupUtils gameGroupUtils)
        {
            _enemyParamsBase = enemyParamsBase;
            _aiAbilityService = aiAbilityService;
            _gameGroupUtils = gameGroupUtils;
        }
        
        public override string Name => TaskNames.USE_ABILITY;

        public override void
            Fill(BehaviorTreeBuilder builder, 
                GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {
                 var ability = entity.ActiveAbility.Value;
                
                 _aiAbilityService.CastAbility(entity, ability);
                
                 entity.RemoveActiveAbility();
                 
                 return TaskStatus.Success;
                
            });
    }
}