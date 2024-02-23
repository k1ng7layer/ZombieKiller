using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Decorators
{
	[Serializable, NodeMenuItem("Decorators/RepeatUntilFailure")]
	public class RepeatUntilFailureNode : ADecoratorNode
	{
		public override string name => BtTaskNames.REPEAT_UNTIL_FAILURE;

	}
}