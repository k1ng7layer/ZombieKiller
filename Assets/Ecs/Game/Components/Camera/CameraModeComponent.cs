using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Camera
{
    [Game]
    [Event(EventTarget.Self)]
    public class CameraModeComponent : IComponent
    {
        public ECameraMode Value;
    }
}