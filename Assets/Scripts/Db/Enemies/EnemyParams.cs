using Game.Utils;
using UnityEngine;

namespace Db.Enemies
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(EnemyParams), fileName = "EnemyParams")]
    public class EnemyParams : ScriptableObject
    {
        public EEnemyType EnemyType;
        public EWeaponId Weapon;

        public float BaseHealth = 100;
        public float BaseExperience = 10;
        public float BaseAttackRange = 3;
        public float BaseMoveSpeed = 3;
        public float BaseAttackSpeed = 1;
    }
}