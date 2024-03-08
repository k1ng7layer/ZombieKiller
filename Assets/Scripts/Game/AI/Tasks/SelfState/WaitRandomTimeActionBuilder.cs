using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using Ecs.Core.Interfaces;
using Game.Models.Ai.Utils;
using Game.Providers.RandomProvider;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.SelfState
{
	[Serializable, NodeMenuItem(TaskNames.WAIT_RANDOM_TIME_PATH)]
	public class WaitRandomTimeActionNode : ABehaviourTreeNode
	{
		[GraphProcessor.Input("In"), Vertical]
		public float input;
		
		public override string name => TaskNames.WAIT_RANDOM_TIME;
	}
	public class WaitRandomTimeActionBuilder : ATaskBuilder
	{
		private readonly ITimeProvider _timeProvider;
		private readonly IRandomProvider _randomProvider;

		public WaitRandomTimeActionBuilder(
			ITimeProvider timeProvider,
			IRandomProvider randomProvider
		)
		{
			_timeProvider = timeProvider;
			_randomProvider = randomProvider;
		}

		public override string Name => TaskNames.WAIT_RANDOM_TIME;

		public override void Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues)
			=> builder.WaitCustomTime(Name, _timeProvider, () => _randomProvider.Range(1f, 3f));
	}
}