using JCMG.EntitasRedux;

namespace Ecs.Game.Components.UnitParameters
{
    [Game]
    [Event(EventTarget.Self)]
    public class AttackSpeedComponent : IComponent
    {
        public float Value;
    }
}