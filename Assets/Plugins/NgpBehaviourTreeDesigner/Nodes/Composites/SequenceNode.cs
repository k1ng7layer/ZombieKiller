using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Composites
{
	[Serializable, NodeMenuItem("Composites/Sequence")]
	public class SequenceNode : ACompositeNode
	{
		public override string name => BtTaskNames.SEQUENCE;

	}
}