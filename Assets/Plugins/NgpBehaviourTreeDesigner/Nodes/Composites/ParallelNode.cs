using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Composites
{
	[Serializable, NodeMenuItem("Composites/Parallel")]
	public class ParallelNode : ACompositeNode
	{
		public override string name => BtTaskNames.PARALLEL;

	}
}