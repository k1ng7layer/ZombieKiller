using GraphProcessor;
using UnityEngine;

namespace Plugins.NgpBehaviourTreeDesigner.Editor
{
    public class BehaviourTreeGraphWindow : BaseGraphWindow
    {
        public BaseGraph Graph => graph;

        protected override void OnDestroy()
        {
            graphView?.Dispose();

        }

        protected override void InitializeWindow(BaseGraph graph)
        {
            titleContent = new GUIContent(graph.name);

            if (graphView == null)
                graphView = new BaseGraphView(this);

            rootView.Add(graphView);
        }
    }
}