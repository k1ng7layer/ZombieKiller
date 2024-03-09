using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Db.Enemies;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.SWITCH_TO_AA_PATH)]
    public class SwitchToAutoAttacksActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
        
        public override string name => TaskNames.SWITCH_TO_AA;
    }
    
    public class SwitchToAutoAttacksActionBuilder : ATaskBuilder
    {
        private readonly IEnemyParamsBase _enemyParamsBase;

        public SwitchToAutoAttacksActionBuilder(IEnemyParamsBase enemyParamsBase)
        {
            _enemyParamsBase = enemyParamsBase;
        }
        
        public override string Name => TaskNames.SWITCH_TO_AA;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {
                
                var enemyParams = _enemyParamsBase.GetEnemyParams(entity.Enemy.EnemyType);
                
                entity.ReplaceAttackRange(enemyParams.BaseAttackRange);

                return TaskStatus.Success;
                
            });
    }
}