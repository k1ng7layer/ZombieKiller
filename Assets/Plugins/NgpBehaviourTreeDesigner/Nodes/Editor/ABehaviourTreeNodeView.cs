using GraphProcessor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Plugins.NgpBehaviourTreeDesigner.Nodes.Editor
{
    public abstract class ABehaviourTreeNodeView : BaseNodeView
    {
        protected abstract string IconName { get; }
        
        public override void Enable()
        {
            var icon = AssetDatabase.LoadAssetAtPath<Texture2D>($"Assets/Plugins/NgpBehaviourTreeDesigner/Editor/Icons/{IconName}.png");
            var image = new Image
            {
                image = icon
            };
            controlsContainer.Add(image);
        }
    }
}