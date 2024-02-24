using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Components.Ai
{
    [Game]
    [Event(EventTarget.Self)]
    public class DestinationComponent : IComponent
    {
        public Vector3 Value;
    }
}