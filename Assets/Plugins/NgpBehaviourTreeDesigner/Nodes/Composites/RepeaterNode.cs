using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Composites
{
	[Serializable, NodeMenuItem("Composites/Repeater")]
	public class RepeaterNode : ACompositeNode
	{
		public override string name => BtTaskNames.REPEATER;

	}
}