using System;
using UnityEngine;

namespace Game.Utils
{

    [Serializable]
    public class EnemySpawnPointSettings
    {
        public Transform SpawnTransform;
        public EEnemyType EnemyType;
    }
}