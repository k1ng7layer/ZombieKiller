using System;
using System.Collections.Generic;
using Db.Items.Impl;
using Game.Utils;
using UnityEngine;

namespace Db.Items.Repositories.Impl
{
    [CreateAssetMenu(menuName = "Settings/Items/Repositories/" + nameof(PotionRepository), fileName = "PotionRepository")]
    public class PotionRepository : ItemRepository<Potion>, 
        IPotionRepository
    {
        [SerializeField] private List<Potion> _items;

        public override List<Potion> Items => _items;
        
        public Potion Get(EPotionType potionType)
        {
            foreach (var item in Items)
            {
                if (item.PotionType == potionType)
                    return item;
            }
            
            throw new Exception($"[{typeof(PotionRepository)}]: Can't find potion with type: {potionType}");
        }
    }
}