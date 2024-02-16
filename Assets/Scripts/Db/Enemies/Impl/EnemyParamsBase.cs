using System;
using Game.Utils;
using UnityEngine;

namespace Db.Enemies.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(EnemyParamsBase), fileName = "WeaponBase")]
    public class EnemyParamsBase : ScriptableObject, IEnemyParamsBase
    {
        [SerializeField] private EnemyParams[] enemyParamsArray;
        
        public EnemyParams GetEnemyParams(EEnemyType enemyType)
        {
            foreach (var enemyParams in enemyParamsArray)
            {
                if (enemyParams.EnemyType == enemyType)
                    return enemyParams;
            }
            
            throw new Exception($"[{typeof(EnemyParamsBase)}]: Can't find params for enemy type: {enemyType}");
        }
    }
}