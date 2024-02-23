using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CleverCrow.Fluid.BTs.Trees.Editors {
    [CustomPropertyDrawer(typeof(BehaviorTree))]
    public class BehaviorTreeDrawer : PropertyDrawer {
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty(position, label, property);
            
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            GUI.enabled = Application.isPlaying;

            if (GUI.Button(position, "View Tree"))
            {
                var fieldValue = fieldInfo.GetValue(property.serializedObject.targetObject);
                if (fieldValue is IBehaviorTree tree)
                {
                    RenderTree(tree, property);
                }
                else if (fieldValue is IEnumerable<IBehaviorTree> trees)
                {
                    foreach(var t in trees)
                        RenderTree(t, property);
                }
            }
            
            GUI.enabled = true;
            EditorGUI.EndProperty();
        }

        private static void RenderTree(IBehaviorTree tree, SerializedProperty property)
        {
            BehaviorTreeWindow.ShowTree(tree, tree.Name ?? property.displayName);
        }
    }
}
