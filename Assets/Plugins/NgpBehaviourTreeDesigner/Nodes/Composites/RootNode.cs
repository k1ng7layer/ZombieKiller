using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Composites
{
	[System.Serializable, NodeMenuItem("Root")]
	public class RootNode : ABehaviourTreeNode
	{
		[Output("Out"), Vertical]
		public float	output;

		public override string name => "Root";

	}
}