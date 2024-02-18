using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    [Event(EventTarget.Self)]
    public class UnitLevelComponent : IComponent
    {
        public int Value;
    }
}