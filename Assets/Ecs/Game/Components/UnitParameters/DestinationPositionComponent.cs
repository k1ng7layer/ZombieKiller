using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Components.UnitParameters
{
    [Game]
    [Event(EventTarget.Self)]
    public class DestinationPositionComponent : IComponent
    {
        public Vector3 Value;
    }
}