using JCMG.EntitasRedux;
using UnityEngine;
using EventType = JCMG.EntitasRedux.EventType;

namespace Ecs.Game.Components
{
    [Game]
    [Event(EventTarget.Self)]
    [Event(EventTarget.Self, EventType.Removed)]
    public class MoveDirectionComponent : IComponent
    {
        public Vector3 Value;
    }
}