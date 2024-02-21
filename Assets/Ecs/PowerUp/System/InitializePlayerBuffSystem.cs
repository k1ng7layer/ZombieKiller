using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.PowerUp.System
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 60, nameof(EFeatures.Initialization))]
    public class InitializePlayerBuffSystem : IInitializeSystem
    {
        private readonly PowerUpContext _powerUp;

        public InitializePlayerBuffSystem(PowerUpContext powerUp)
        {
            _powerUp = powerUp;
        }
        
        public void Initialize()
        {
            _powerUp.IsPlayerPowerUp = true;
        }
    }
}