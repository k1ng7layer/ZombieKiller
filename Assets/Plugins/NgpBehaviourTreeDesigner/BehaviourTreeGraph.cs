using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes.Composites;

namespace Plugins.NgpBehaviourTreeDesigner
{
    public class BehaviourTreeGraph : BaseGraph
    {
        public RootNode GetRoot()
        {
            return nodes[0] as RootNode;
        }
    }
}