using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Composites
{
	[Serializable, NodeMenuItem("Composites/SelectorRepeater")]
	public class SelectorRepeaterNode : ACompositeNode
	{
		public override string name => BtTaskNames.SELECTOR_REPEATER;

	}
}