using JCMG.EntitasRedux;
using UnityEngine.AI;

namespace Ecs.Game.Components.Ai
{
    [Game]
    public class NavmeshAgentComponent : IComponent
    {
        public NavMeshAgent Value;
    }
}