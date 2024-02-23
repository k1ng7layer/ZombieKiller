using System;
using System.Collections.Generic;
using GraphProcessor;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes
{
    public abstract class ABehaviourTreeNode : BaseNode
    {
        public List<ABehaviourTreeNode> ChildNodes
        {
            get
            {
                var outputNodes = GetOutputNodes();
                var res = new List<ABehaviourTreeNode>();
                ParseNodes(outputNodes, res);
                res.Sort(new RectComparer());
                return res;
            }
        }

        public virtual Dictionary<string, object> Values { get; } = new();
        
        private struct RectComparer : IComparer<ABehaviourTreeNode>
        {
            public int Compare(ABehaviourTreeNode x, ABehaviourTreeNode y)
            {
                return x.position.x.CompareTo(y.position.x);
            }
        }

        private void ParseNodes(IEnumerable<BaseNode> nodes, List<ABehaviourTreeNode> parsedNodes)
        {
            foreach (var outputNode in nodes)
            {
                var behaviourTreeNode = outputNode as ABehaviourTreeNode;
                if (outputNode is RelayNode relay)
                {
                    var relayNodes = relay.GetOutputNodes();
                    ParseNodes(relayNodes, parsedNodes);
                    continue;
                }

                if (behaviourTreeNode == null)
                    throw new ArgumentException(
                        $"BehaviourTreeNode should have type ABehaviourTreeNode not {outputNode.GetType().Name}");
                parsedNodes.Add(behaviourTreeNode);
            }
        }
    }
}