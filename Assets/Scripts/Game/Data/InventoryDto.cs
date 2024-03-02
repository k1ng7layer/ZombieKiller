using System;
using System.Collections.Generic;

namespace Game.Data
{
    [Serializable]
    public class InventoryDto
    {
        public int Capacity;
        public List<string> Items;
        public List<string> EquippedItems;
    }
}