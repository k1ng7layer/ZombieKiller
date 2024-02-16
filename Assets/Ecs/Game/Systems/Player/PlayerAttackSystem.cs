using Game.Services.InputService;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems.Player
{
    public class PlayerAttackSystem : IInitializeSystem
    {
        private readonly IInputService _inputService;

        public PlayerAttackSystem(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        public void Initialize()
        {
            
        }
    }
}