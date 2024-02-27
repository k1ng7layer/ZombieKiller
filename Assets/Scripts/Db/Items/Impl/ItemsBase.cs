using System;
using System.Collections.Generic;
using Db.Items.Repositories.Impl;
using Game.Extensions;
using Game.Utils;
using Unity.Collections;
using UnityEditor;
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
            //GenerateIds();
        }
        

        public Item GetItem(string id)
        {
            foreach (var item in _items)
            {
                if (item.Id == id)
                    return item;
            }

            throw new Exception($"[{nameof(ItemsBase)}] can't find item with id {id}");
        }

        public void GenerateIds()
        {
            OnValidate();

            foreach (var item in _items)
            {
                if (item.Id == string.Empty)
                {
                     item.Id = CorrelationIdGenerator.GetNextId();
                     EditorUtility.SetDirty(item);
                    //item.Id = Guid.NewGuid().CreateShortGuid();
                    //Thread.Sleep(1);
                }
            }
           
            AssetDatabase.SaveAssets();
        }
    }
    
}