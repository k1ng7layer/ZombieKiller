using Db.Weapon;
using Game.Utils;
using UnityEngine;

namespace Db.Items.Impl
{
    [CreateAssetMenu(menuName = "Settings/Items/" + nameof(Weapon), fileName = "WeaponItem")]
    public class Weapon : Item
    {
        public EWeaponType WeaponType;
        
        [Space]
        [Header("Combat params")]
        public float PhysicalDamage;
        public float MagicDamage;
        public ProjectileSettings ProjectileSettings;
        
        public override object[] GetDescriptionArgs()
        {
            return new object[] { PhysicalDamage, MagicDamage };
        }
    }
}