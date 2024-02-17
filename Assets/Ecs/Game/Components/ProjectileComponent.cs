using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    public class ProjectileComponent : IComponent
    {
        public EProjectileType ProjectileType;
    }
}