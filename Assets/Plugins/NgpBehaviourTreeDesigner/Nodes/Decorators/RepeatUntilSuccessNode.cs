using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Decorators
{
	[Serializable, NodeMenuItem("Decorators/repeatUntilSuccess")]
	public class RepeatUntilSuccessNode : ADecoratorNode
	{
		public override string name => BtTaskNames.REPEAT_UNTIL_SUCCESS;

	}
}