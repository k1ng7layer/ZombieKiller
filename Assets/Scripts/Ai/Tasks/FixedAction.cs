using Ai.SharedVariables;
using JCMG.EntitasRedux.Commands;
using Zenject;

namespace Ai.Tasks
{
    public class FixedAction : BehaviorDesigner.Runtime.Tasks.Action
    {
        public SharedUid SharedUid;
        
        protected GameEntity SelfEntity;
        [Inject] protected GameContext Game;
        [Inject] protected ICommandBuffer CommandBuffer;
        
        public override void OnStart()
        {
            var uid = SharedUid.Value;
            SelfEntity = Game.GetEntityWithUid(uid);
        }
    }
}