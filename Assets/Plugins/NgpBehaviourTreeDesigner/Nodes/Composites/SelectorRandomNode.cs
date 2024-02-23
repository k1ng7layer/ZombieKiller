using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Composites
{
	[Serializable, NodeMenuItem("Composites/SelectorRandom")]
	public class SelectorRandomNode : ACompositeNode
	{
		public override string name => BtTaskNames.SELECTOR_RANDOM;

	}
}