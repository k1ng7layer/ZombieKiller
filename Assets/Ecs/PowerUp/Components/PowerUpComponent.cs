using JCMG.EntitasRedux;

namespace Ecs.PowerUp.Components
{
    [PowerUp]
    [Event(EventTarget.Self)]
    [Event(EventTarget.Any)]
    [Event(EventTarget.Self, EventType.Removed)]
    [Event(EventTarget.Any, EventType.Removed)]
    public class PowerUpComponent : IComponent
    {
        public int Id;
    }
}