
using System.Collections.Generic;
using Db.Enemies;
using Db.Weapon;
using Ecs.Extensions.UidGenerator;
using Game.Utils;
using UnityEngine;

namespace Ecs.Game.Extensions
{
    public static class GameExtensions
    {
        public static GameEntity CreateWeapon(this GameContext game, 
            EWeaponId weaponId, 
            WeaponSettings weaponSettings, 
            Uid owner
        )
        {
            var weaponEntity = game.CreateEntity();
            var weaponUid = UidGenerator.Next();
            weaponEntity.AddUid(weaponUid);
            weaponEntity.AddWeapon(weaponId);
            weaponEntity.AddOwner(owner);
            weaponEntity.AddPrefab(weaponId.ToString());
            weaponEntity.AddAttackTargets(new HashSet<Uid>());
            weaponEntity.AddPhysicalDamage(weaponSettings.PhysicalDamage);
            weaponEntity.AddMagicDamage(weaponSettings.MagicDamage);
            weaponEntity.IsInstantiate = true;

            return weaponEntity;
        }

        public static GameEntity CreateProjectile(this GameContext game, 
            EProjectileType projectileType,
            Uid owner, 
            float speed,
            Vector3 position, 
            Quaternion rotation,
            float physicalDamage,
            float magicDamage
        )
        {
            var projectileEntity = game.CreateEntity();
            projectileEntity.AddProjectile(projectileType);
            projectileEntity.ReplaceAttackTargets(new HashSet<Uid>());
            projectileEntity.AddOwner(owner);
            projectileEntity.AddRotation(rotation);
            projectileEntity.AddPosition(position);
            projectileEntity.AddSpeed(speed);
            projectileEntity.AddPhysicalDamage(physicalDamage);
            projectileEntity.AddMagicDamage(magicDamage);
            return projectileEntity;
        }
        
        public static GameEntity CreateEnemy(
            this GameContext game, 
            EEnemyType enemyType,
            EnemyParams enemyParams,
            Vector3 position, 
            Quaternion rotation
        )
        {
            var enemyEntity = game.CreateEntity();
            
            enemyEntity.AddEnemy(enemyType);
            enemyEntity.AddPosition(position);
            enemyEntity.AddRotation(rotation);
            enemyEntity.AddPrefab(enemyType.ToString());
            enemyEntity.AddHealth(enemyParams.BaseHealth);
            enemyEntity.AddAttackRange(enemyParams.AttackRange);
            enemyEntity.AddAttackCooldown(enemyParams.AttackCooldown);
            enemyEntity.AddTime(0);
            enemyEntity.AddUid(UidGenerator.Next());
            enemyEntity.IsInstantiate = true;
            
            return enemyEntity;
        }
    }
}