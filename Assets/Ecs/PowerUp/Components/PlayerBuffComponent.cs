using JCMG.EntitasRedux;

namespace Ecs.PowerUp.Components
{
    [PowerUp]
    [Event(EventTarget.Any)]
    [Event(EventTarget.Self, EventType.Removed)]
    public class PlayerBuffComponent : IComponent
    {
        
    }
}