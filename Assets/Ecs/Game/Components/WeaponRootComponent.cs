using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Components
{
    [Game]
    public class WeaponRootComponent : IComponent
    {
        public Transform Value;
    }
}