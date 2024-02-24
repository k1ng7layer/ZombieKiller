using Ecs.Commands.Command.Combat;
using Ecs.Utils.LinkedEntityRepository;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Commands.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 205, nameof(EFeatures.Combat))]
    public class TakeDamageSystem : ForEachCommandUpdateSystem<TakeDamageByWeaponCommand>
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly ILinkedEntityRepository _linkedEntityRepository;

        public TakeDamageSystem(
            ICommandBuffer commandBuffer, 
            ILinkedEntityRepository linkedEntityRepository
        ) : base(commandBuffer)
        {
            _commandBuffer = commandBuffer;
            _linkedEntityRepository = linkedEntityRepository;
        }

        protected override void Execute(ref TakeDamageByWeaponCommand byWeaponCommand)
        {
            var hasWeapon = _linkedEntityRepository.TryGet(byWeaponCommand.WeaponHash, out var weaponEntity);

            if (!hasWeapon)
                return;
            
            if (!weaponEntity.IsPerformingAttack)
                return;
            
            var weaponTargets = weaponEntity.AttackTargets.Value;
            var hasTargetEntity = _linkedEntityRepository.TryGet(byWeaponCommand.TargetHash, out var targetEntity);
            
            if (!hasTargetEntity)
                return;
            
            var targetUid = targetEntity.Uid.Value;

            var weaponOwner = weaponEntity.Owner.Value;
            
            if (weaponOwner == targetUid)
                return;
            
            if (weaponTargets.Contains(targetUid))
                return;
            
            weaponTargets.Add(targetUid);

            var damage = weaponEntity.PhysicalDamage.Value + weaponEntity.MagicDamage.Value;
            var health = targetEntity.Health.Value;
            health -= damage;
            
            targetEntity.ReplaceHealth(health);

            if (!targetEntity.HasHitCounter)
            {
                targetEntity.AddHitCounter(0);
            }
            else
            {
                var hitCounter = targetEntity.HitCounter.Value;
                targetEntity.ReplaceHitCounter(++hitCounter);
            }
            Debug.Log($"TakeDamageSystem. targetEntity: {targetUid}, damage: {damage}");

            if (weaponEntity.HasProjectile)
            {
                _commandBuffer.DestroyProjectile(weaponEntity.Transform.Value.GetHashCode());
            }
        }
    }
}