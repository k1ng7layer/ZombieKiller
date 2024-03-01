using UnityEngine;

namespace Game.Utils
{
    public readonly struct CollectableInfo
    {
        public readonly EItemType Type;
        public readonly string ItemId;
        public readonly Vector3 DropCenter;

        public CollectableInfo(
            EItemType type, 
            string itemId, 
            Vector3 dropCenter
        )
        {
            Type = type;
            ItemId = itemId;
            DropCenter = dropCenter;
        }
    }
}