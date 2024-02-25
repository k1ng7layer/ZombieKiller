using System;
using System.Collections.Generic;

namespace Game.Services.Inventory
{
    public interface IPlayerInventoryService
    {
        event Action<int> ItemAdded;
        int Capacity { get; }
        bool IsFull { get; }
        IEnumerable<int> GetAll();
        bool TryAdd(int itemId);
        void ChangeCapacity(int capacity);
    }
}