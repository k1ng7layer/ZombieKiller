using System;
using System.Collections.Generic;

namespace Game.Services.Inventory.Impl
{
    public class PlayerInventoryService : IPlayerInventoryService
    {
        private readonly List<int> _items = new();
        public int Capacity { get; private set; }
        public bool IsFull => _items.Count == Capacity;

        public event Action<int> ItemAdded;

        public IEnumerable<int> GetAll()
        {
            return _items;
        }

        public bool TryAdd(int itemId)
        {
            if (_items.Count == Capacity)
                return false;
            
            _items.Add(itemId);
            
            ItemAdded?.Invoke(itemId);

            return true;
        }

        public void ChangeCapacity(int capacity)
        {
            Capacity = capacity;
        }
    }
}