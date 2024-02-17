using System;
using Game.Utils;
using UnityEngine;

namespace Db.Weapon.Impl
{
    [CreateAssetMenu(menuName = "Settings/Weapons" + nameof(WeaponBase), fileName = "WeaponBase")]
    public class WeaponBase : ScriptableObject, IWeaponBase
    {
        [SerializeField] private WeaponSettings[] weapons;
        
        public WeaponSettings GetWeapon(EWeaponId weaponId)
        {
            foreach (var weapon in weapons)
            {
                if (weapon.WeaponId == weaponId)
                    return weapon;
            }
            
            throw new Exception($"[{typeof(WeaponBase)}]: Can't find weapon with name: {weaponId}");
        }
    }
}