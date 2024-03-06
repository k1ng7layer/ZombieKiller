using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Combat
{
    [Game]
    [Event(EventTarget.Self)]
    [Event(EventTarget.Self, EventType.Removed)]
    public class PerformingAttackComponent : IComponent
    {
        
    }
}