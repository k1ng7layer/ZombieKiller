using System;
using System.Collections.Generic;

namespace Game.Services.Inventory
{
    public interface IPlayerInventoryService
    {
        event Action<string> ItemAdded;
        int Capacity { get; }
        bool IsFull { get; }
        IReadOnlyList<string> GetAll();
        bool TryAdd(string itemId);
        void ChangeCapacity(int capacity);
    }
}