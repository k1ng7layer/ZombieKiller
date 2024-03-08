using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    [PowerUp]
    [Event(EventTarget.Self)]
    public class TimerComponent : IComponent
    {
        public float Value;
    }
}