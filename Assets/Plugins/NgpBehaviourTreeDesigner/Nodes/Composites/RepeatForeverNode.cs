using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Composites
{
	[Serializable, NodeMenuItem("Composites/RepeatForever")]
	public class RepeatForeverNode : ACompositeNode
	{
		public override string name => BtTaskNames.REPEAT_FOREVER;

	}
}