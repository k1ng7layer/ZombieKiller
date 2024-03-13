using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Abilities
{
    [Game]
    [Event(EventTarget.Self)]
    [Event(EventTarget.Self, EventType.Removed)]
    public class ActiveAbility : IComponent
    {
        public EAbilityType Value;
    }
}