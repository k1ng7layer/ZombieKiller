using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    [Event(EventTarget.Self)]
    public class ExperienceComponent : IComponent
    {
        public float Value;
    }
}