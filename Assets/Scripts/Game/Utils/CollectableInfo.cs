using UnityEngine;

namespace Game.Utils
{
    public readonly struct CollectableInfo
    {
        public readonly string ItemId;
        public readonly Vector3 DropCenter;

        public CollectableInfo(string itemId, 
            Vector3 dropCenter
        )
        {
            ItemId = itemId;
            DropCenter = dropCenter;
        }
    }
}