using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    public class PortalComponent : IComponent
    {
        public EPortalDestination PortalDestination;
    }
}