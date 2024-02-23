using CleverCrow.Fluid.BTs.Trees;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Ai
{
    [Game]
    [Event(EventTarget.Self)]
    public class BehaviourTreeComponent : IComponent
    {
        public IBehaviorTree Value;
    }
}