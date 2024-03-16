using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Components
{
    [Game]
    public class PushDirectionComponent : IComponent
    {
        public Vector3 Value;
    }
}