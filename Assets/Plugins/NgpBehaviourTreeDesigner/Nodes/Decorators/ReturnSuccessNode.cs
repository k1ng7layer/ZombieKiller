using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Decorators
{
	[Serializable, NodeMenuItem("Decorators/return success")]
	public class ReturnSuccessNode : ADecoratorNode
	{
		public override string name => BtTaskNames.RETURN_SUCCESS;

	}
}