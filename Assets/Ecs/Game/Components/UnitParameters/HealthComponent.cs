using JCMG.EntitasRedux;

namespace Ecs.Game.Components.UnitParameters
{
    [Game]
    [Event(EventTarget.Self)]
    public class HealthComponent : IComponent
    {
        public float Value;
    }
}