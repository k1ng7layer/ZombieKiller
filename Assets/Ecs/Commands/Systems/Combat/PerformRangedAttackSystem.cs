﻿using Db.Items.Repositories;
using Ecs.Commands.Command.Combat;
using Ecs.Game.Extensions;
using Ecs.Utils.LinkedEntityRepository;
using Game.Services.ProjectilePoolRepository;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Commands.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 210, nameof(EFeatures.Combat))]
    public class PerformRangedAttackSystem : ForEachCommandUpdateSystem<PerformAttackCommand>
    {
        private readonly IWeaponRepository _weaponRepository;
        private readonly IProjectilePoolRepository _poolRepository;
        private readonly ILinkedEntityRepository _linkedEntityRepository;
        private readonly GameContext _game;

        public PerformRangedAttackSystem(
            ICommandBuffer commandBuffer, 
            IWeaponRepository weaponRepository,
            IProjectilePoolRepository poolRepository,
            ILinkedEntityRepository linkedEntityRepository,
            GameContext game
        ) : base(commandBuffer)
        {
            _weaponRepository = weaponRepository;
            _poolRepository = poolRepository;
            _linkedEntityRepository = linkedEntityRepository;
            _game = game;
        }

        protected override void Execute(ref PerformAttackCommand command)
        {
            var attacker = _game.GetEntityWithUid(command.Attacker);
            
            var weaponId = attacker.EquippedWeapon.Value.Id;
            var weaponSettings = _weaponRepository.GetWeapon(weaponId);
            
            if (weaponSettings.WeaponType != EWeaponType.Ranged)
                return;
            
            var weaponEntity = _game.GetEntityWithUid(attacker.EquippedWeapon.Value.WeaponEntityUid);
            var projectileType = weaponSettings.ProjectileSettings.ProjectileType;
            var projectileRepository = _poolRepository.GetPool(projectileType);
            var weaponOwner = _game.GetEntityWithUid(weaponEntity.Owner.Value);
            
            var projectileView = projectileRepository.Spawn();
           
            
            var ownerForward = weaponOwner.Transform.Value.forward;
            var rotation = Quaternion.LookRotation(ownerForward);
            var weaponRoot = weaponOwner.WeaponRoot.Value;
            var destination = (rotation * Vector3.forward) * 100f;
            
            var projectileEntity = _game.CreateProjectile(
                projectileType,
                weaponEntity.Owner.Value,
                weaponSettings.ProjectileSettings.ProjectileSpeed, 
                weaponRoot.position, 
                rotation, 
                weaponSettings.PhysicalDamage, 
                weaponSettings.MagicDamage);
            
            projectileEntity.AddDestination(destination);
            
            Debug.Log($"Projectile spawn: {projectileView.transform.GetHashCode()}");
            
            projectileEntity.IsPerformingAttack = true;
            
            projectileView.Link(projectileEntity);
            projectileEntity.AddLink(projectileView);
            
            _linkedEntityRepository.Add(projectileView.transform.GetHashCode(), projectileEntity);

            projectileEntity.IsActive = true;
        }
    }
}