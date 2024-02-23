using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Composites
{
	[Serializable, NodeMenuItem("Composites/AsyncParallel")]
	public class AsyncParallelNode : ACompositeNode
	{
		public override string name => BtTaskNames.ASYNC_PARALLEL;

	}
}