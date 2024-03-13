using Ecs.Views.Linkable.Impl;
using Game.Utils;
using Zenject;

namespace Game.Services.Pools.Explosion
{
    public interface IExplosionPool : IMemoryPool<ExplosionView>
    {
        EExplosionType ExplosionType { get; }
    }
}