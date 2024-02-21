using Ai.SharedVariables;
using BehaviorDesigner.Runtime.Tasks;
using Zenject;

namespace Ai
{
    public class FixedConditional : Conditional
    {
        public SharedUid SharedUid;
        
        protected GameEntity SelfEntity;
        [Inject] protected GameContext Game;
        
        public override void OnStart()
        {
            var uid = SharedUid.Value;
            SelfEntity = Game.GetEntityWithUid(uid);
        }
    }
}