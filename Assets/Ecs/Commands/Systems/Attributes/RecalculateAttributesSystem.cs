using Db.PowerUps;
using Ecs.Commands.Command.Attributes;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Commands.Systems.Attributes
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 760, nameof(EFeatures.Combat))]
    public class RecalculateAttributesSystem : ForEachCommandUpdateSystem<RecalculateUnitAttributesCommand>
    {
        private readonly IPowerUpBase _powerUpBase;
        private readonly PowerUpContext _powerUp;
        private readonly GameContext _game;

        public RecalculateAttributesSystem(
            ICommandBuffer commandBuffer,
            IPowerUpBase powerUpBase,
            PowerUpContext powerUp,
            GameContext game
        ) : base(commandBuffer)
        {
            _powerUpBase = powerUpBase;
            _powerUp = powerUp;
            _game = game;
        }

        protected override void Execute(ref RecalculateUnitAttributesCommand command)
        {
            Debug.Log($"RecalculateUnitAttributesCommand");
            var powerUps = _powerUp.GetEntitiesWithOwner(command.UnitUid);
            var powerUpOwner = _game.GetEntityWithUid(command.UnitUid);
            var ownerLevel = powerUpOwner.UnitLevel.Value;
            
            powerUpOwner.ReplaceAdditionalPhysicalDamage(0);
            powerUpOwner.ReplaceAdditionalMagicDamage(0);
            powerUpOwner.ReplaceMaxHealth(powerUpOwner.BaseMaxHealth.Value);
            
            foreach (var powerUpEntity in powerUps)
            {
                var powerUpParams = _powerUpBase.Get(powerUpEntity.PowerUp.Id);

                foreach (var powerUpStat in powerUpParams.UnitStatsGain)
                {
                    var delta = powerUpStat.Value * powerUpParams.NextGradeValueMultiplier;
                    float value;
                    float newValue;
                    switch (powerUpStat.StatType)
                    {
                        case EUnitStat.HEALTH:
                            value = powerUpOwner.MaxHealth.Value;
                            newValue = Recalculate(powerUpStat.Operation, value, delta);
                            powerUpOwner.ReplaceMaxHealth(newValue);
                            Debug.Log($"increase health: {newValue}");
                            break;
                        case EUnitStat.MOVE_SPEED:
                            break;
                        case EUnitStat.ARMOR:
                            break;
                        case EUnitStat.ATTACK_DAMAGE:
                            value = powerUpOwner.AdditionalPhysicalDamage.Value;
                            newValue = Recalculate(powerUpStat.Operation, value, delta);
                            powerUpOwner.ReplaceAdditionalPhysicalDamage(newValue);
                            powerUpOwner.ReplacePhysicalDamage(powerUpOwner.PhysicalDamage.Value + newValue);
                            break;
                        case EUnitStat.ABILITY_POWER:
                            value = powerUpOwner.AdditionalMagicDamage.Value;
                            newValue = Recalculate(powerUpStat.Operation, value, delta);
                            powerUpOwner.ReplaceAdditionalMagicDamage(newValue);
                            powerUpOwner.ReplaceMagicDamage(powerUpOwner.MagicDamage.Value + newValue);
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
    }
}