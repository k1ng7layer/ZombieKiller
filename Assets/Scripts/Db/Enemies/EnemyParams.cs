using Game.Utils;
using UnityEngine;

namespace Db.Enemies
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(EnemyParams), fileName = "EnemyParams")]
    public class EnemyParams : ScriptableObject
    {
        public EEnemyType EnemyType;

        public float BaseHealth;
        public float AttackRange;
        public float AttackCooldown;
    }
}