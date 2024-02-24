using Db.PowerUps;
using Ecs.Commands.Command.PowerUp;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems.PowerUp
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 820, nameof(EFeatures.Combat))]
    public class DeactivatePowerUpSystem : ForEachCommandUpdateSystem<DeactivatePowerUpCommand>
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly PowerUpContext _powerUp;
        private readonly IPowerUpBase _powerUpBase;
        private readonly GameContext _game;

        public DeactivatePowerUpSystem(
            ICommandBuffer commandBuffer,
            PowerUpContext powerUp,
            IPowerUpBase powerUpBase,
            GameContext game
        ) : base(commandBuffer)
        {
            _commandBuffer = commandBuffer;
            _powerUp = powerUp;
            _powerUpBase = powerUpBase;
            _game = game;
        }

        protected override void Execute(ref DeactivatePowerUpCommand command)
        {
            var powerUpEntity = _powerUp.GetEntityWithUid(command.PowerUpUid);
            powerUpEntity.IsPlayerBuff = false;
            powerUpEntity.IsDestroyed = true;
            var powerUpId = powerUpEntity.PowerUp.Id;
            var powerUpParams = _powerUpBase.Get(powerUpId);
            var owner = powerUpEntity.Owner.Value;
            var ownerEntity = _game.GetEntityWithUid(owner);
           
            foreach (var powerUpParam in powerUpParams.UnitStatsGain)
            {
                if (powerUpParam.StatType != EUnitStat.HEALTH)
                    continue;

                var maxHealth = ownerEntity.MaxHealth.Value;
                
                switch (powerUpParam.Operation)
                {
                    case EOperation.Add:
                        maxHealth -= powerUpParam.Value;
                        ownerEntity.ReplaceMaxHealth(maxHealth);
                        break;
                    case EOperation.Subtract:
                        maxHealth += powerUpParam.Value;
                        ownerEntity.ReplaceMaxHealth(maxHealth);
                        break;
                    case EOperation.Multiply:
                        maxHealth /= powerUpParam.Value;
                        ownerEntity.ReplaceMaxHealth(maxHealth);
                        break;
                }
            }
            
            _commandBuffer.RecalculateUnitAttributes(owner);
            
            powerUpEntity.RemovePowerUp();
        }
    }
}