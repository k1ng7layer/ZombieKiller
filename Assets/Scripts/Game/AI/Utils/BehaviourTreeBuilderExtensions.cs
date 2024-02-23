using System;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;
using Ecs.Core.Interfaces;
using Game.Models.Ai.Utils.TaskParents.Composites;
using Game.Models.Ai.Utils.Tasks;
using Game.Models.Ai.Utils.Tasks.WaitTime;
using Game.Providers.RandomProvider;

namespace Game.Models.Ai.Utils
{
	public static class BehaviourTreeBuilderExtensions
	{
		public static BehaviorTreeBuilder Do(this BehaviorTreeBuilder builder,
			string name,
			Action startLogic,
			Func<TaskStatus> updateLogic
		)
			=> builder.AddNode(new ActionGeneric
			{
				Name = name,
				startLogic = startLogic,
				updateLogic = updateLogic
			});

		public static BehaviorTreeBuilder Do(this BehaviorTreeBuilder builder,
			string name,
			Action startLogic,
			Func<TaskStatus> updateLogic,
			Action exitLogic
		)
			=> builder.AddNode(new ActionGeneric
			{
				Name = name,
				startLogic = startLogic,
				updateLogic = updateLogic,
				exitLogic = exitLogic
			});

		public static BehaviorTreeBuilder WaitTime(this BehaviorTreeBuilder builder, string name,
			ITimeProvider timeProvider,
			float delay)
			=> builder.AddNode(new WaitTimeWithProvider(timeProvider) {Name = name, Delay = delay});

		public static BehaviorTreeBuilder WaitTime(this BehaviorTreeBuilder builder, string name,
			ITimeProvider timeProvider,
			float delay,
			Action continueLogic)
			=> builder.AddNode(new WaitTimeWithProvider(timeProvider)
			{
				Name = name,
				Delay = delay,
				ContinueLogic = continueLogic
			});

		public static BehaviorTreeBuilder SkipTicks(this BehaviorTreeBuilder builder, string name, int ticksToSkip)
			=> builder.AddNode(new SkipTicksAction(ticksToSkip));

		public static BehaviorTreeBuilder WaitTime(this BehaviorTreeBuilder builder, string name,
			ITimeProvider timeProvider,
			float delay,
			Action startLogic,
			Action continueLogic)
			=> builder.AddNode(new WaitTimeWithProvider(timeProvider)
			{
				Name = name,
				Delay = delay,
				StartLogic = startLogic,
				ContinueLogic = continueLogic
			});

		public static BehaviorTreeBuilder WaitCustomTime(this BehaviorTreeBuilder builder, string name,
			ITimeProvider timeProvider,
			Func<float> delayFunc)
			=> builder.AddNode(new WaitCustomTimeWithProvider(timeProvider)
			{
				Name = name,
				DelayFunc = delayFunc
			});

		public static BehaviorTreeBuilder WaitCustomTime(this BehaviorTreeBuilder builder, string name,
			ITimeProvider timeProvider,
			Func<float> delayFunc,
			Action continueLogic)
			=> builder.AddNode(new WaitCustomTimeWithProvider(timeProvider)
			{
				Name = name,
				DelayFunc = delayFunc,
				ContinueLogic = continueLogic
			});

		public static BehaviorTreeBuilder Repeater(this BehaviorTreeBuilder builder, string name = "repeater")
			=> builder.ParentTask<Repeater>(name);

		public static BehaviorTreeBuilder RepeatAllUntilFailure(this BehaviorTreeBuilder builder, string name = "repeatAllUntilFailure")
			=> builder.ParentTask<RepeatAllUntilFailure>(name);

		public static BehaviorTreeBuilder SelectorRepeater(this BehaviorTreeBuilder builder,
			string name = "selector repeater")
			=> builder.ParentTask<SelectorRepeater>(name);

		public static BehaviorTreeBuilder RandomChance(this BehaviorTreeBuilder builder, string name,
			IRandomProvider randomProvider, Func<float> chanceGetter)
			=> builder.AddNode(new CustomRandomChance(randomProvider, chanceGetter) {Name = name});
	}
}