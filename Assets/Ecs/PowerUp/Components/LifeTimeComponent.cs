using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.PowerUp.Components
{
    [PowerUp]
    public class LifeTimeComponent : IComponent
    {
        public EPowerUpLifeTime Value;
    }
}