using System;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Decorators
{
    [Serializable]
    public abstract class ADecoratorNode : ABehaviourTreeNode
    {
        [Input("In"), Vertical]
        public float input;
		
        [Output("Out"), Vertical]
        public float output;
    }
}