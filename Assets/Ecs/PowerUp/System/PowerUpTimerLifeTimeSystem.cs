using Ecs.Commands;
using Ecs.Core.Interfaces;
using Ecs.Utils.Groups.Impl;
using Game.Utils;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.PowerUp.System
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 810, nameof(EFeatures.Combat))]
    public class PowerUpTimerLifeTimeSystem : IUpdateSystem
    {
        private readonly PowerUpGroupUtils _powerUpGroupUtils;
        private readonly ITimeProvider _timeProvider;
        private readonly ICommandBuffer _commandBuffer;

        public PowerUpTimerLifeTimeSystem(
            PowerUpGroupUtils powerUpGroupUtils, 
            ITimeProvider timeProvider,
            ICommandBuffer commandBuffer
        )
        {
            _powerUpGroupUtils = powerUpGroupUtils;
            _timeProvider = timeProvider;
            _commandBuffer = commandBuffer;
        }
        
        public void Update()
        {
            using var powerUpGroup = _powerUpGroupUtils
                .GetActivePowerUps(out var powerUpEntities, 
                    p => p.HasLifeTime && 
                         p.LifeTime.Value == EPowerUpLifeTime.Temporary && 
                         p.HasResource);
            
            foreach (var powerUpEntity in powerUpEntities)
            {
                var timer = powerUpEntity.Resource.Value;
                timer -= _timeProvider.DeltaTime;
                
                powerUpEntity.ReplaceResource(timer);

                if (timer <= 0)
                {
                    Debug.Log($"PowerUpTimerLifeTimeSystem");
                    _commandBuffer.DeactivatePowerUp(powerUpEntity.Uid.Value);
                }
            }
        }
    }
}