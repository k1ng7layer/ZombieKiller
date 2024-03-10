using Game.Services.Pools.Explosion;
using Game.Utils;

namespace Game.Services.ExplosionPoolRepository
{
    public interface IExplosionPoolRepository
    {
        IExplosionPool Get(EExplosionType explosionType);
    }
}