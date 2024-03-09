using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Conditions
{
    [Serializable, NodeMenuItem(TaskNames.HAS_WEAPON_PATH)]
    public class HasWeaponConditionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
        
        public override string name => TaskNames.HAS_WEAPON;
    }
    
    public class HasWeaponConditionBuilder : ATaskBuilder
    {
        public override string Name => TaskNames.HAS_WEAPON;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) =>
            builder.Condition(Name,
                () => entity.HasEquippedWeapon);
    }
}