using Ecs.Extensions.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    [PowerUp]
    public class OwnerComponent : IComponent
    {
        [EntityIndex]
        public Uid Value;
    }
}