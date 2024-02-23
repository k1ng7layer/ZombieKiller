using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Decorators
{
	[Serializable, NodeMenuItem("Decorators/return failure")]
	public class ReturnFailureNode : ADecoratorNode
	{
		public override string name => BtTaskNames.RETURN_FAILURE;

	}
}