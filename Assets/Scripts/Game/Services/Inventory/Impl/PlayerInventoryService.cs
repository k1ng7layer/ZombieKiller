using System;
using System.Collections.Generic;
using Db.Inventory;
using Game.Data;
using Game.Services.Dao;
using Zenject;

namespace Game.Services.Inventory.Impl
{
    public class PlayerInventoryService : IPlayerInventoryService, 
        IInitializable
    {
        private readonly IDao<GameData> _gameData;
        private readonly IPlayerInventorySettings _playerInventorySettings;
        private readonly List<string> _items = new();

        public PlayerInventoryService(
            IDao<GameData> gameData, 
            IPlayerInventorySettings playerInventorySettings
        )
        {
            _gameData = gameData;
            _playerInventorySettings = playerInventorySettings;
        }

        public event Action<string> ItemRemoved;
        public int Capacity { get; private set; }
        public bool IsFull => _items.Count == Capacity;

        public event Action<string> ItemAdded;
        
        public void Initialize()
        {
            var data = _gameData.Load();

            var items = data == null ? 
                _playerInventorySettings.StarterItemsIds : 
                data.Inventory.Items;
            
            var capacity = data == null ? 
                _playerInventorySettings.BasicCapacity : 
                data.Inventory.Capacity;
          
            ChangeCapacity(capacity);

            foreach (var starterItemId in items)
            {
                TryAdd(starterItemId);
            }
        }

        public IReadOnlyList<string> GetAll()
        {
            return _items;
        }

        public bool TryAdd(string itemId)
        {
            if (_items.Count == Capacity)
                return false;
            
            _items.Add(itemId);
            
            ItemAdded?.Invoke(itemId);

            return true;
        }

        public bool TryRemove(string itemId)
        {
            if (!_items.Contains(itemId))
                return false;

            var result = _items.Remove(itemId);
            
            if (result)
                ItemRemoved?.Invoke(itemId);

            return result;
        }

        public void ChangeCapacity(int capacity)
        {
            Capacity = capacity;
        }
    }
}