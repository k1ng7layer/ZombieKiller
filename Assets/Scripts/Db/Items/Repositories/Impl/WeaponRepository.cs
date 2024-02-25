using System;
using System.Collections.Generic;
using Game.Utils;
using UnityEngine;

namespace Db.Items.Repositories.Impl
{
    [CreateAssetMenu(menuName = "Settings/Items/Repositories/" + nameof(WeaponRepository), fileName = "WeaponRepository")]
    public class WeaponRepository : ItemRepository<Items.Impl.Weapon>, IWeaponRepository
    {
        [SerializeField] private List<Items.Impl.Weapon> _items;

        public override List<Items.Impl.Weapon> Items => _items;
        
        public Items.Impl.Weapon GetWeapon(EWeaponId weaponId)
        {
            foreach (var weapon in Items)
            {
                if (weapon.WeaponId == weaponId)
                    return weapon;
            }
            
            throw new Exception($"[{typeof(WeaponRepository)}]: Can't find weapon with name: {weaponId}");
        }

        
    }
}