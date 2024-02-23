using System.Linq;
using GraphProcessor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Plugins.NgpBehaviourTreeDesigner.Editor
{
    [CustomEditor(typeof(BehaviourTreeGraph), true)]
    public class GraphAssetInspector : GraphInspector
    {
        protected override void CreateInspector()
        {
            base.CreateInspector();

            root.Add(new Button(() =>
            {
                var openedGraphs = Resources.FindObjectsOfTypeAll<BehaviourTreeGraphWindow>();

                var baseGraph = target as BaseGraph;

                var windowWithGraph = openedGraphs.FirstOrDefault(w => w.Graph == baseGraph);
                if(windowWithGraph)
                    windowWithGraph.Focus();
                else
                    EditorWindow.CreateWindow<BehaviourTreeGraphWindow>().InitializeGraph(baseGraph);
            })
            {
                text = "Open base graph window"
            });
        }
    }
}