using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes.Composites;
using Plugins.NgpBehaviourTreeDesigner.Nodes.Decorators;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Editor
{
    [NodeCustomEditor(typeof(RootNode))]
    public class RootNodeView : ABehaviourTreeNodeView
    {
        protected override string IconName => "Root";
    }
    
    [NodeCustomEditor(typeof(AsyncParallelNode))]
    public class AsyncParallelNodeView : ABehaviourTreeNodeView
    {
        protected override string IconName => "Parallel";
    }
    
    [NodeCustomEditor(typeof(ParallelNode))]
    public class ParallelNodeView : ABehaviourTreeNodeView
    {
        protected override string IconName => "Parallel";
    }
    
    [NodeCustomEditor(typeof(RepeaterNode))]
    public class RepeaterNodeView : ABehaviourTreeNodeView
    {
        protected override string IconName => "Repeater";
    }
    
    [NodeCustomEditor(typeof(RepeatForeverNode))]
    public class RepeatForeverNodeView : ABehaviourTreeNodeView
    {
        protected override string IconName => "Repeat";
    }

    [NodeCustomEditor(typeof(SelectorNode))]
    public class SelectorNodeView : ABehaviourTreeNodeView
    {
        protected override string IconName => "Selector";
    }
    
    [NodeCustomEditor(typeof(SelectorRandomNode))]
    public class SelectorRandomNodeView : ABehaviourTreeNodeView
    {
        protected override string IconName => "SelectorRandom";
    }
    
    [NodeCustomEditor(typeof(SelectorRepeaterNode))]
    public class SelectorRepeaterNodeView : ABehaviourTreeNodeView
    {
        protected override string IconName => "Selector";
    }
    
    [NodeCustomEditor(typeof(SequenceNode))]
    public class SequenceNodeView : ABehaviourTreeNodeView
    {
        protected override string IconName => "Sequence";
    }
    
    
    [NodeCustomEditor(typeof(InverterNode))]
    public class InverterNodeView : ABehaviourTreeNodeView
    {
        protected override string IconName => "Inverter";
    }
    
    [NodeCustomEditor(typeof(RepeatUntilFailureNode))]
    public class RepeatUntilFailureNodeView : ABehaviourTreeNodeView
    {
        protected override string IconName => "Repeater";
    }
    
    [NodeCustomEditor(typeof(RepeatUntilSuccessNode))]
    public class RepeatUntilSuccessNodeView : ABehaviourTreeNodeView
    {
        protected override string IconName => "RepeatUntilSuccess";
    }
    
    [NodeCustomEditor(typeof(ReturnFailureNode))]
    public class ReturnFailureNodeView : ABehaviourTreeNodeView
    {
        protected override string IconName => null;
    }
}