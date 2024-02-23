using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Decorators
{
	[Serializable, NodeMenuItem("Decorators/Invertor")]
	public class InverterNode : ADecoratorNode
	{
		public override string name => BtTaskNames.INVERTER;

	}
}