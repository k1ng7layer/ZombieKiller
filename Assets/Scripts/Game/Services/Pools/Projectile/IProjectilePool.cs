using Ecs.Views.Linkable.Impl.Projectiles;
using Game.Utils;
using Zenject;

namespace Game.Services.Pools.Projectile
{
    public interface IProjectilePool : IMemoryPool<ProjectileView>
    {
        EProjectileType ProjectileType { get; }
    }
}