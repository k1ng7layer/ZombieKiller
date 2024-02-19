using System;
using Game.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Db.Weapon
{
    [CreateAssetMenu(menuName = "Settings/Weapons/" + nameof(WeaponSettings), fileName = "Weapon")]
    public class WeaponSettings : ScriptableObject
    {
        public EWeaponId WeaponId;
        public EWeaponType WeaponType;
        public Image Icon;
        
        [Space]
        [Header("Combat params")]
        public float PhysicalDamage;
        public float MagicDamage;
        public ProjectileSettings ProjectileSettings;
    }
    
    [Serializable]
    public struct ProjectileSettings
    {
        public EProjectileType ProjectileType;
        public float ProjectileSpeed;
    }
}