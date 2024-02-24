using System;
using System.Collections.Generic;
using Game.Utils;
using UnityEngine;

namespace Db.PowerUps
{
    [CreateAssetMenu(menuName = "Settings/PowerUps/" + nameof(PowerUpSettings), fileName = "PowerUpSettings")]
    public class PowerUpSettings : ScriptableObject
    {
        [Header("Visual params")]
        public Sprite Icon;
        public string Name;
        public string Description;
        
        [Space]
        [Header("Life cycle params")]
        public List<PowerUpStat> UnitStatsGain;
        public int MinExpRequired;
        public float NextGradeValueMultiplier;
        public LifeTime LifeTime;
    }

    [Serializable]
    public class PowerUpStat
    {
        public EUnitStat StatType;
        public int Value;
        public EOperation Operation;
    }

    [Serializable]
    public class LifeTime
    {
        public EPowerUpLifeTime LifeTimeType;
        public float LifeTimeValue;
    }
}