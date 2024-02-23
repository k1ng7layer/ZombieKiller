using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using Game.AI;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.Models.Ai.Tasks.Default
{
    [Serializable, NodeMenuItem(DefaultTaskNames.SUCCESS_WITH_CHANCE_PATH)]
    public class SuccessWithChanceNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;

        public int chance = 1;
        public int outOf = 100;

        public override Dictionary<string, object> Values =>
            new()
            {
                { TaskParametersNames.CHANCE, chance },
                { TaskParametersNames.OUTOF, outOf }
            };

        public override string name => DefaultTaskNames.SUCCESS_WITH_CHANCE;
    }

    public class SuccessWithChanceActionBuilder : ATaskBuilder
    {
        public override string Name => DefaultTaskNames.SUCCESS_WITH_CHANCE;

        public override void Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues)
        {
            var chance = (int)taskValues[TaskParametersNames.CHANCE];
            var outOf = (int)taskValues[TaskParametersNames.OUTOF];
            builder.RandomChance(Name, chance, outOf);
        }
    }
}