using Game.Utils;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Components
{
    [Game]
    public class TrajectoryComponent : IComponent
    {
        public TrajectoryInfo Value;
    }
}