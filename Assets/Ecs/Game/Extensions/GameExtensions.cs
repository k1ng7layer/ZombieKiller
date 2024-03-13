
using System.Collections.Generic;
using Db.Items.Impl;
using Ecs.Extensions.UidGenerator;
using Game.Utils;
using UnityEngine;

namespace Ecs.Game.Extensions
{
    public static class GameExtensions
    {
        public static GameEntity CreateWeapon(this GameContext game, 
            string weaponId, 
            Weapon weapon, 
            Uid owner,
            bool spawn = true
        )
        {
            var weaponEntity = game.CreateEntity();
            var weaponUid = UidGenerator.Next();
            weaponEntity.AddUid(weaponUid);
            weaponEntity.AddWeapon(weaponId);
            weaponEntity.AddOwner(owner);
            weaponEntity.AddPrefab(weapon.Name);
            weaponEntity.AddAttackTargets(new HashSet<Uid>());
            weaponEntity.AddPhysicalDamage(weapon.PhysicalDamage);
            weaponEntity.AddMagicDamage(weapon.MagicDamage);
            weaponEntity.IsInstantiate = spawn;

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

        // public static void AddUnitAttributes(GameEntity entity, float maxHealth, float)
        // {
        //     
        // }
    }
}