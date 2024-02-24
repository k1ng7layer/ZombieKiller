using System.Linq;
using GraphProcessor;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Plugins.NgpBehaviourTreeDesigner.Editor
{
    public class GraphAssetCallbacks
    {
        [MenuItem("Assets/Create/Behaviour tree", false, 10)]
        public static void CreateGraphProcessor()
        {
            var graph = ScriptableObject.CreateInstance<BehaviourTreeGraph>();
            ProjectWindowUtil.CreateAsset(graph, "BehaviourTreeGraph.asset");
        }
	
        [OnOpenAsset(0)]
        public static bool OnBaseGraphOpened(int instanceID, int line)
        {
            var asset = EditorUtility.InstanceIDToObject(instanceID) as BehaviourTreeGraph;

            if (asset != null)
            {
                var openedGraphs = Resources.FindObjectsOfTypeAll<BehaviourTreeGraphWindow>();

                var baseGraph = (BaseGraph)asset;

                var windowWithGraph = openedGraphs.FirstOrDefault(w => w.Graph == baseGraph);
                if(windowWithGraph)
                    windowWithGraph.Focus();
                else
                    EditorWindow.CreateWindow<BehaviourTreeGraphWindow>().InitializeGraph(baseGraph);
                return true;
            }
            return false;
        }
    }
}