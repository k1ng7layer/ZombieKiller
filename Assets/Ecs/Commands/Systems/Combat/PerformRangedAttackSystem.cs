
using Db.Weapon;
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
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 200, nameof(EFeatures.Combat))]
    public class PerformRangedAttackSystem : ForEachCommandUpdateSystem<PerformAttackCommand>
    {
        private readonly IWeaponBase _weaponBase;
        private readonly IProjectilePoolRepository _poolRepository;
        private readonly ILinkedEntityRepository _linkedEntityRepository;
        private readonly GameContext _game;

        public PerformRangedAttackSystem(
            ICommandBuffer commandBuffer, 
            IWeaponBase weaponBase,
            IProjectilePoolRepository poolRepository,
            ILinkedEntityRepository linkedEntityRepository,
            GameContext game
        ) : base(commandBuffer)
        {
            _weaponBase = weaponBase;
            _poolRepository = poolRepository;
            _linkedEntityRepository = linkedEntityRepository;
            _game = game;
        }

        protected override void Execute(ref PerformAttackCommand command)
        {
            var attacker = _game.GetEntityWithUid(command.Attacker);
            
            var weaponId = attacker.EquippedWeapon.Value.Id;
            var weaponSettings = _weaponBase.GetWeapon(weaponId);
            
            if (weaponSettings.WeaponType != EWeaponType.Ranged)
                return;

            if (attacker.IsPerformingAttack)
                return;
            
            attacker.IsPerformingAttack = true;
            
            var weaponEntity = _game.GetEntityWithUid(attacker.EquippedWeapon.Value.WeaponEntityUid);
            var projectileType = weaponSettings.ProjectileSettings.ProjectileType;
            var projectileRepository = _poolRepository.GetPool(projectileType);
            var weaponOwner = _game.GetEntityWithUid(weaponEntity.Owner.Value);
            
            var projectileView = projectileRepository.Spawn();
            var ownerForward = weaponOwner.Transform.Value.forward;
            var rotation = Quaternion.LookRotation(ownerForward);
            var weaponRoot = weaponOwner.WeaponRoot.Value;
            
            var projectileEntity = _game.CreateProjectile(
                projectileType,
                weaponEntity.Owner.Value,
                weaponSettings.ProjectileSettings.ProjectileSpeed, 
                weaponRoot.position, 
                rotation, 
                weaponSettings.PhysicalDamage, 
                weaponSettings.MagicDamage);
            
            projectileEntity.IsPerformingAttack = true;
            
            projectileView.Link(projectileEntity);
            projectileEntity.AddLink(projectileView);
            
            _linkedEntityRepository.Add(projectileView.transform.GetHashCode(), projectileEntity);

            projectileEntity.IsActive = true;
        }
    }
}