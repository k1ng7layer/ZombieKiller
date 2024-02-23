using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using Game.AI;
using Game.AI.Tasks;
using Game.Providers.RandomProvider;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.Models.Ai.Tasks.SelfState
{
	[Serializable, NodeMenuItem(TaskNames.WAIT_TIME_PATH)]
	public class WaitTimeActionNode : ABehaviourTreeNode
	{
		[GraphProcessor.Input("In"), Vertical]
		public float input;
		
		public float minWaitTime = 2;
		public float maxWaitTime = 6;
		
		public override Dictionary<string, object> Values =>
			new()
			{
				{ TaskParametersNames.MIN_WAIT_TIME, minWaitTime },
				{ TaskParametersNames.MAX_WAIT_TIME, maxWaitTime }
			};

		public override string name => TaskNames.WAIT_TIME;
	}

	public class WaitTimeActionBuilder : ATaskBuilder
	{
		private readonly IRandomProvider _randomProvider;
		
		public override string Name => TaskNames.WAIT_TIME;

		public WaitTimeActionBuilder(IRandomProvider randomProvider)
		{
			_randomProvider = randomProvider;
		}

		public override void Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues)
		{
			var min = (float)taskValues[TaskParametersNames.MIN_WAIT_TIME];
			var max = (float)taskValues[TaskParametersNames.MAX_WAIT_TIME];
			var time = _randomProvider.Range(min, max);
			builder.WaitTime(time);
		}
	}
}