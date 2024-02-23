using Ecs.Extensions.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Ai
{
    [Game]
    public class TargetComponent : IComponent
    {
        public Uid TargetUid;
    }
}