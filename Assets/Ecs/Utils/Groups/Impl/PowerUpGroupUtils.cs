using System;
using System.Collections.Generic;
using Game.Utils;
using JCMG.EntitasRedux;
using UnityEngine.Pool;

namespace Ecs.Utils.Groups.Impl
{
    public class PowerUpGroupUtils
    {
        private readonly IGroup<PowerUpEntity> _powerUpsGroup;

        public PowerUpGroupUtils(PowerUpContext powerUp)
        {
            _powerUpsGroup = powerUp.GetGroup(PowerUpMatcher.PowerUp);
        }
        
        private IDisposable GetEntities(
            out List<PowerUpEntity> buffer,  
            IGroup<PowerUpEntity> group,
            Func<PowerUpEntity, bool> baseFilter, 
            Func<PowerUpEntity, bool> filter = null)
        {
            var pooledObject = ListPool<PowerUpEntity>.Get(out buffer);
            group.GetEntities(buffer);
            
            if (filter != null)
            {
                buffer.RemoveAllWithSwap(e => !(baseFilter(e) && filter(e)));    
            }
            else
            {
                buffer.RemoveAllWithSwap(e => !baseFilter(e));
            }
            
            return pooledObject;
        }
        
        public IDisposable GetActivePowerUps(out List<PowerUpEntity> buffer, Func<PowerUpEntity, bool> filter = null)
        {
            Func<PowerUpEntity, bool> baseFilter = e => e.HasPowerUp && !e.IsDestroyed;

            return GetEntities(out buffer, _powerUpsGroup, baseFilter, filter);
        }
    }
}