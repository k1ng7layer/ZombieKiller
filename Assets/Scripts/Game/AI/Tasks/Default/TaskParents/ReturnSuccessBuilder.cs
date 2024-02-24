using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.Models.Ai.Tasks.Default.TaskParents
{
	[Serializable, NodeMenuItem(DefaultTaskNames.RETURN_SUCCESS)]
	public class ReturnSuccessScriptable : ABehaviourTreeNode
	{
		[GraphProcessor.Input("In"), Vertical]
		public float input;
	}

	
	public class ReturnSuccessBuilder : ATaskParentBuilder
	{
		public override string Name => DefaultTaskNames.RETURN_SUCCESS;

		public override void Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues)
			=> builder.ReturnSuccess();
	}
}