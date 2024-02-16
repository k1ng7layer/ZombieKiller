using System;
using UnityEngine;

namespace Db.Weapon.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(WeaponBase), fileName = "WeaponBase")]
    public class WeaponBase : ScriptableObject, IWeaponBase
    {
        [SerializeField] private WeaponSettings[] weapons;
        
        public WeaponSettings GetWeapon(string weaponName)
        {
            foreach (var weapon in weapons)
            {
                if (weapon.Name == weaponName)
                    return weapon;
            }
            
            throw new Exception($"[{typeof(WeaponBase)}]: Can't find weapon with name: {weaponName}");
        }
    }
}