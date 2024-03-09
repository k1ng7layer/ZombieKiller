using Game.Utils;
using UnityEngine;

namespace Db.Abilities
{
    [CreateAssetMenu(menuName = "Settings/Abilities/" + nameof(Ability), fileName = "Ability")]
    public class Ability : ScriptableObject
    {
        public EAbilityType AbilityType;
        public float Damage;
        public float Reload;
        public float Speed;
    }
}