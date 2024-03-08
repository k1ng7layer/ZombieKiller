using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Composites
{
	[Serializable, NodeMenuItem("Composites/Selector")]
	public class SelectorNode : ACompositeNode
	{
		public override string name => BtTaskNames.SELECTOR;

	}
}