using JCMG.EntitasRedux;

namespace Ecs.Game.Components.UnitParameters
{
    [Game]
    [Event(EventTarget.Self)]
    public class MaxHealthComponent : IComponent
    {
        public float Value;
    }
}