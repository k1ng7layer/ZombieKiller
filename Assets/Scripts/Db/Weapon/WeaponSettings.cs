using Game.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Db.Weapon
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(WeaponSettings), fileName = "Weapon")]
    public class WeaponSettings : ScriptableObject
    {
        public string Name;
        public EWeaponType WeaponType;
        public Image Icon;
        
        [Space]
        [Header("Combat params")]
        public float PhysicalDamage;
        public float MagicDamage;
    }
}