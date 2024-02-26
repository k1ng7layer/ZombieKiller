using System;
using System.Collections.Generic;
using UnityEngine;

namespace Db.Items.Repositories.Impl
{
    [CreateAssetMenu(menuName = "Settings/Items/Repositories/" + nameof(WeaponRepository), fileName = "WeaponRepository")]
    public class WeaponRepository : ItemRepository<Items.Impl.Weapon>, 
        IWeaponRepository
    {
        [SerializeField] private List<Items.Impl.Weapon> _items;

        public override List<Items.Impl.Weapon> Items => _items;
        
        public Items.Impl.Weapon GetWeapon(string weaponId)
        {
            foreach (var weapon in Items)
            {
                if (weapon.Id == weaponId)
                    return weapon;
            }
            
            throw new Exception($"[{typeof(WeaponRepository)}]: Can't find weapon with name: {weaponId}");
        }

        
    }
}