using Db.PowerUps;
using Ecs.Commands.Command.PowerUp;
using Ecs.Utils.Groups.Impl;
using Game.Providers.RandomProvider;
using JCMG.EntitasRedux.Commands;

namespace Ecs.Commands.Systems.PowerUp
{
    //[Install(ExecutionType.Game, ExecutionPriority.Normal, 750, nameof(EFeatures.Combat))]
    public class CreatePowerUpSystem : ForEachCommandUpdateSystem<CreatePowerUp>
    {
        private readonly IPowerUpBase _powerUpBase;
        private readonly IRandomProvider _randomProvider;
        private readonly PowerUpGroupUtils _powerUpGroupUtils;
        private readonly PowerUpContext _powerUp;

        public CreatePowerUpSystem(
            ICommandBuffer commandBuffer, 
            IPowerUpBase powerUpBase,
            IRandomProvider randomProvider,
            PowerUpGroupUtils powerUpGroupUtils,
            PowerUpContext powerUp
        ) : base(commandBuffer)
        {
            _powerUpBase = powerUpBase;
            _randomProvider = randomProvider;
            _powerUpGroupUtils = powerUpGroupUtils;
            _powerUp = powerUp;
        }

        protected override void Execute(ref CreatePowerUp command)
        {
           using var powerUpGroup = _powerUpGroupUtils.GetActivePowerUps(out var buffer, p => p.IsActive);

           var powerUps = _powerUpBase.PowerUpS;
           var randomId = _randomProvider.Range(0, powerUps.Count);
          
           var powerUpEntity = _powerUp.CreateEntity();
           
           powerUpEntity.AddPowerUp(randomId);
           powerUpEntity.AddOwner(command.Owner);

           // if (randomPowerUpSettings.LifeTime.LifeTimeType is EPowerUpLifeTime.Temporary or EPowerUpLifeTime.Charges)
           // {
           //     powerUpEntity.AddResource(randomPowerUpSettings.LifeTime.LifeTimeValue);
           // }
        }
    }
}