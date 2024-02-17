using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.View;

namespace Ecs.Game.Components
{
    [Game]
    [Event(EventTarget.Self, EventType.Removed)]
    public class LinkComponent : IComponent
    {
        public ILinkable View;
    }
}