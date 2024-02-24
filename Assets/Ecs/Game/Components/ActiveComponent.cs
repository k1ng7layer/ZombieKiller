using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    [PowerUp]
    [Event(EventTarget.Self)]
    [Event(EventTarget.Self, EventType.Removed)]
    public class ActiveComponent : IComponent
    {
        
    }
}