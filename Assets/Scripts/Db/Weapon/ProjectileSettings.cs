using System;
using Game.Utils;

namespace Db.Weapon
{
    [Serializable]
    public struct ProjectileSettings
    {
        public EProjectileType ProjectileType;
        public float ProjectileSpeed;
    }
}