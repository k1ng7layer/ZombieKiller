using JCMG.EntitasRedux;

namespace Ecs.PowerUp.Components
{
    [PowerUp]
    [Event(EventTarget.Self)]
    public class ResourceComponent : IComponent
    {
        public float Value;
    }
}