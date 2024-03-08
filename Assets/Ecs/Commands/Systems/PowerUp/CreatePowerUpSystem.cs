using Db.PowerUps;
using Ecs.Commands.Command.PowerUp;
using Ecs.Extensions.UidGenerator;
using Ecs.Utils.Groups.Impl;
using Game.Providers.RandomProvider;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Commands.Systems.PowerUp
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 750, nameof(EFeatures.Combat))]
    public class CreatePowerUpSystem : ForEachCommandUpdateSystem<CreatePowerUpCommand>
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly IPowerUpBase _powerUpBase;
        private readonly IRandomProvider _randomProvider;
        private readonly PowerUpGroupUtils _powerUpGroupUtils;
        private readonly PowerUpContext _powerUp;
        private readonly GameContext _game;

        public CreatePowerUpSystem(
            ICommandBuffer commandBuffer, 
            IPowerUpBase powerUpBase,
            IRandomProvider randomProvider,
            PowerUpGroupUtils powerUpGroupUtils,
            PowerUpContext powerUp,
            GameContext game
        ) : base(commandBuffer)
        {
            _commandBuffer = commandBuffer;
            _powerUpBase = powerUpBase;
            _randomProvider = randomProvider;
            _powerUpGroupUtils = powerUpGroupUtils;
            _powerUp = powerUp;
            _game = game;
        }

        protected override void Execute(ref CreatePowerUpCommand command)
        {
           using var powerUpGroup = _powerUpGroupUtils.GetActivePowerUps(out var buffer, p => p.IsActive);

           Debug.Log($"CreatePowerUpSystem");
           
           var powerUps = _powerUpBase.PowerUpS;
           var randomId = _randomProvider.Range(0, powerUps.Count);
           var powerUpSettings = _powerUpBase.PowerUpS[randomId];
           var ownerEntity = _game.GetEntityWithUid(command.Owner);

           if (powerUpSettings.LifeTime.LifeTimeType != EPowerUpLifeTime.Permanent)
           {
               CreateTemporaryPowerUp(randomId, command.Owner);
           }
           else
           {
               foreach (var powerUpStat in powerUpSettings.UnitStatsGain)
               {
                   switch (powerUpStat.StatType)
                   {
                       case EUnitStat.HEALTH:
                           var maxHealth = ownerEntity.MaxHealth.Value;
                           var newHealth = Recalculate(powerUpStat.Operation, maxHealth, powerUpStat.Value);
                           ownerEntity.ReplaceMaxHealth(newHealth);
                           ownerEntity.ReplaceBaseMaxHealth(newHealth);
                           break;
                       case EUnitStat.MOVE_SPEED:
                           break;
                       case EUnitStat.ARMOR:
                           break;
                       case EUnitStat.ATTACK_DAMAGE:
                           var dmg = ownerEntity.PhysicalDamage.Value;
                           var newDmg = Recalculate(powerUpStat.Operation, dmg, powerUpStat.Value);
                           ownerEntity.ReplacePhysicalDamage(newDmg);
                           break;
                       case EUnitStat.ABILITY_POWER:
                           // var maxHealth = ownerEntity.MaxHealth.Value;
                           // var newHealth = Recalculate(powerUpStat.Operation, maxHealth, powerUpStat.Value);
                           // ownerEntity.ReplaceMaxHealth(newHealth);
                           // ownerEntity.ReplaceBaseMaxHealth(newHealth);
                           break;
                   }
               }
           }
          
        }
        
        private float Recalculate(EOperation operation, float current, float delta)
        {
            switch (operation)
            {
                case EOperation.Add:
                    current += delta;
                    break;
                case EOperation.Subtract:
                    current -= delta;
                    break;
                case EOperation.Multiply:
                    current *= delta;
                    break;
            }

            return current;
        }

        private void CreateTemporaryPowerUp(int powerUpId, Uid owner)
        {
            var powerUpSettings = _powerUpBase.PowerUpS[powerUpId];
            var powerUpEntity = _powerUp.CreateEntity();
            var powerUpOwner = _game.GetEntityWithUid(owner);
           
            powerUpEntity.AddPowerUp(powerUpId);
            powerUpEntity.AddOwner(owner);
            powerUpEntity.IsActive = true;
            powerUpEntity.AddUid(UidGenerator.Next());
            powerUpEntity.AddLifeTime(powerUpSettings.LifeTime.LifeTimeType);
            powerUpEntity.IsPlayerBuff = powerUpOwner.IsPlayer;
           
           
            if (powerUpSettings.LifeTime.LifeTimeType is EPowerUpLifeTime.Temporary or EPowerUpLifeTime.Charges)
            {
                powerUpEntity.AddResource(powerUpSettings.LifeTime.LifeTimeValue);
            }
           
            _commandBuffer.RecalculateUnitAttributes(owner);
        }
    }
}