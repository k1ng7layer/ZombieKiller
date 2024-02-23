using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Combat
{
    [Game]
    [Event(EventTarget.Self)]
    public class HitCounterComponent : IComponent
    {
        public int Value;
    }
}