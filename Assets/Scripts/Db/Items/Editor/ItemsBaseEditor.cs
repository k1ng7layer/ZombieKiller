using Db.Items.Impl;
using UnityEditor;
using UnityEngine;

namespace Db.Items.Editor
{
    [CustomEditor(typeof(ItemsBase))]
    public class ItemsBaseEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var itemBase = (ItemsBase)target;
            
            if (GUILayout.Button("Generate Ids"))
            {
                itemBase.GenerateIds();
            }
        }
    }
}