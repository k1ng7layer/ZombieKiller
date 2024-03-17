using UnityEngine;

namespace Db.Items
{
    public abstract class Item : ScriptableObject
    {
        [SerializeField]
        public string Id;
        public string Name;
        public string Description;
        public Sprite Icon;
        public bool Usable;
        
        public abstract object[] GetDescriptionArgs();
    }
}
