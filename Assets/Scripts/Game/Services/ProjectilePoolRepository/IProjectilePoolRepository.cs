using Game.Services.Pools.Projectile;
using Game.Utils;

namespace Game.Services.ProjectilePoolRepository
{
    public interface IProjectilePoolRepository
    {
        IProjectilePool GetPool(EProjectileType projectileType);
    }
}