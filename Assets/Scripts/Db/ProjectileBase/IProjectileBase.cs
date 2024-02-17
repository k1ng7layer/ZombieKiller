using Game.Utils;
using UnityEngine;

namespace Db.ProjectileBase
{
    public interface IProjectileBase
    {
        GameObject Get(EProjectileType projectileType);
    }
}