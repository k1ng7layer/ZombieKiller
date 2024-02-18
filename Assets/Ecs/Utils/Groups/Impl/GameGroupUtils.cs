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
        private readonly IGroup<GameEntity> _projectiles;
        private readonly IGroup<GameEntity> _enemiesGroup;
        private readonly IGroup<GameEntity> _portalGroup;

        public GameGroupUtils(GameContext game)
        {
            _projectiles = game.GetGroup(GameMatcher.Projectile);
            _enemiesGroup = game.GetGroup(GameMatcher.Enemy);
            _portalGroup = game.GetGroup(GameMatcher.Portal);
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

        public IDisposable GetProjectiles(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null)
        {
            Func<GameEntity, bool> baseFilter = e => e.HasProjectile && !e.IsDestroyed;

            return GetEntities(out buffer, _projectiles, baseFilter, filter);
        }

        public IDisposable GetEnemies(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null)
        {
            Func<GameEntity, bool> baseFilter = e => e.HasEnemy && !e.IsDestroyed;

            return GetEntities(out buffer, _enemiesGroup, baseFilter, filter);
        }

        public IDisposable GetStagePortals(out List<GameEntity> buffer, Func<GameEntity, bool> filter = null)
        {
            Func<GameEntity, bool> baseFilter = e => e.HasPortal && !e.IsDestroyed;

            return GetEntities(out buffer, _portalGroup, baseFilter, filter);
        }
    }
}