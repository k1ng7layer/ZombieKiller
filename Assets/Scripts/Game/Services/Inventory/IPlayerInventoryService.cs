using System;
using System.Collections.Generic;

namespace Game.Services.Inventory
{
    public interface IPlayerInventoryService
    {
        event Action<string> ItemAdded;
        event Action<string> ItemRemoved;
        int Capacity { get; }
        bool IsFull { get; }
        IReadOnlyList<string> GetAll();
        bool TryAdd(string itemId);
        bool TryRemove(string itemId);
        void ChangeCapacity(int capacity);
    }
}