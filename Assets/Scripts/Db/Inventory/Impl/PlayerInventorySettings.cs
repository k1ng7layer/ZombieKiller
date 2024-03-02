using System.Collections.Generic;
using UnityEngine;

namespace Db.Inventory.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PlayerInventorySettings), fileName = "PlayerInventorySettings")]
    public class PlayerInventorySettings : ScriptableObject,  IPlayerInventorySettings
    {
        [SerializeField] private int _basicCapacity;
        [SerializeField] private string[] _starterItemsIds;

        public int BasicCapacity => _basicCapacity;

        public IReadOnlyList<string> StarterItemsIds => _starterItemsIds;
    }
}