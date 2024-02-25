using System.Collections.Generic;
using Db.Items.Repositories.Impl;
using Unity.Collections;
using UnityEngine;

namespace Db.Items.Impl
{
    [CreateAssetMenu(menuName = "Settings/Items/" + nameof(ItemsBase), fileName = "ItemsBase")]
    public class ItemsBase : ScriptableObject, IItemsBase
    {
        [SerializeField] private ItemRepository<Weapon> _weaponRepo;
        [SerializeField] private ItemRepository<Potion> _potionRepo;
        
        [ReadOnly]
        [SerializeField] private List<Item> _items;
        
        private List<Weapon> _weapons;
        private List<Potion> _potions;
        
        private void OnValidate()
        {
            _items.Clear();
            
            _items.AddRange(_weaponRepo.Items);
            _items.AddRange(_potionRepo.Items);
        }

        public Item GetItem(int id)
        {
            return _items[id];
        }
    }
    
}