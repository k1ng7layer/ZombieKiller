using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Composites
{
    [Serializable]
    public abstract class ACompositeNode : ABehaviourTreeNode
    {
        [Input("In"), Vertical]
        public float input;
		
        [Output("Out"), Vertical]
        public float output;
    }
}