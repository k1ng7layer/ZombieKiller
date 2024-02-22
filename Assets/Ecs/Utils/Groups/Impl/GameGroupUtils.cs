using System;
using System.Collections.Generic;
using Game.Utils;
using JCMG.EntitasRedux;
using UnityEngine.Pool;

namespace Ecs.Utils.Groups.Impl
{
    public class GameGroupUtils : IGameGroupUtils
    {
        private readonly IGroup<GameEntity> _unitsGroup;
        private readonly IGroup<GameEntity> _buildingSlotsGroup;
        private readonly IGroup<GameEntity> _buildingsGroup;
        private readonly IGroup<GameEntity> _enemyBuildingSlot;
        private readonly IGroup<GameEntity> _projectiles;
        private readonly IGroup<GameEntity> _timeGroup;

        public GameGroupUtils(GameContext game)
        {
            _projectiles = game.GetGroup(GameMatcher.Projectile);
            _timeGroup = game.GetGroup(GameMatcher.Time);
        }
        
        public IDisposable GetProjectiles(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null)
        {
            Func<GameEntity, bool> baseFilter = e => e.HasProjectile && !e.IsDestroyed;

            return GetEntities(out buffer, _projectiles, baseFilter, filter);
        }

        public IDisposable GetTimeEntities(out List<GameEntity> buffer, bool isTimeEnd, Func<GameEntity, bool> filter = null)
        {
            Func<GameEntity, bool> baseFilter = isTimeEnd
                ? e => e.HasTime && e.Time.Value <= 0 && !e.IsDestroyed
                : e => e.HasTime && e.Time.Value > 0 && !e.IsDestroyed;
            
            return GetEntities(out buffer, _timeGroup, baseFilter, filter);
        }

        public IDisposable GetUnits(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null, bool nonDestroyed = true)
        {
            Func<GameEntity, bool> baseFilter = nonDestroyed
                ? e => !e.IsDestroyed
                : e => e.IsDestroyed;
            
            return GetEntities(out buffer, _unitsGroup, baseFilter, filter);
        }
        
        public IDisposable GetNotDestroyedUnits(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null, bool isDead = false)
        {
            Func<GameEntity, bool> baseFilter = isDead
                ? e => e.IsDead && !e.IsDestroyed
                : e => !e.IsDead && !e.IsDestroyed;
            
            return GetEntities(out buffer, _unitsGroup, baseFilter, filter);
        }

        public IDisposable GetOwnerUnits(out List<GameEntity> buffer, bool isPlayerUnits, Func<GameEntity, bool> filter = null)
        {
            Func<GameEntity, bool> baseFilter = isPlayerUnits
                ? e => e.IsPlayer && !e.IsDead && !e.IsDestroyed
                : e => !e.IsPlayer && !e.IsDead && !e.IsDestroyed;
            
            return GetEntities(out buffer, _unitsGroup, baseFilter, filter);
        }
        

        private IDisposable GetEntities(
            out List<GameEntity> buffer,  
            IGroup<GameEntity> group,
            Func<GameEntity, bool> baseFilter, 
            Func<GameEntity, bool> filter = null)
        {
            var pooledObject = ListPool<GameEntity>.Get(out buffer);
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
    }
}