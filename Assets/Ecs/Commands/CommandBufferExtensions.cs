//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Commands Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using JCMG.EntitasRedux.Commands;
using Ecs.Commands.Systems.Spawn;
using Game.Utils;
using UnityEngine;
using Ecs.Commands.Command;
using Ecs.Extensions.UidGenerator;
using System;
using Game.Utils.Units;
using Ecs.Commands.Command.PowerUp;
using Ecs.Commands.Command.Input;
using Ecs.Commands.Command.Income;
using Ecs.Commands.Command.Combat;
using Ecs.Commands.Command.Attributes;

namespace Ecs.Commands
{
    public static partial class CommandBufferExtensions
    {
        public static void SpawnEnemy(this ICommandBuffer commandBuffer, EEnemyType enemyType, Vector3 position, Quaternion rotation)
        {
            ref var command = ref commandBuffer.Create<SpawnEnemyCommand>();
            command.EnemyType = enemyType;
            command.Position = position;
            command.Rotation = rotation;
        }

        public static void AttachWeapon(this ICommandBuffer commandBuffer, Uid weapon, Transform transform)
        {
            ref var command = ref commandBuffer.Create<AttachWeaponCommand>();
            command.Weapon = weapon;
            command.Transform = transform;
        }

        public static void EquipWeapon(this ICommandBuffer commandBuffer, EWeaponId weaponId, Uid owner)
        {
            ref var command = ref commandBuffer.Create<EquipWeaponCommand>();
            command.WeaponId = weaponId;
            command.Owner = owner;
        }

        public static void LoadNextStage(this ICommandBuffer commandBuffer)
        {
            ref var command = ref commandBuffer.Create<LoadNextStageCommand>();
        }

        public static void LoadShelter(this ICommandBuffer commandBuffer)
        {
            ref var command = ref commandBuffer.Create<LoadShelterCommand>();
        }

        public static void MouseDown(this ICommandBuffer commandBuffer, Int32 button)
        {
            ref var command = ref commandBuffer.Create<MouseDownCommand>();
            command.Button = button;
        }

        public static void SpawnUnit(this ICommandBuffer commandBuffer, Vector3 position, Quaternion rotation, EUnitType unitType, Boolean isPlayerUnit)
        {
            ref var command = ref commandBuffer.Create<SpawnUnitCommand>();
            command.Position = position;
            command.Rotation = rotation;
            command.UnitType = unitType;
            command.IsPlayerUnit = isPlayerUnit;
        }

        public static void StageWin(this ICommandBuffer commandBuffer)
        {
            ref var command = ref commandBuffer.Create<StageWinCommand>();
        }

        public static void TeleportPlayer(this ICommandBuffer commandBuffer, Int32 portalHash)
        {
            ref var command = ref commandBuffer.Create<TeleportPlayerCommand>();
            command.PortalHash = portalHash;
        }

        public static void CreatePowerUp(this ICommandBuffer commandBuffer, Uid owner, Int32 id)
        {
            ref var command = ref commandBuffer.Create<CreatePowerUpCommand>();
            command.Owner = owner;
            command.Id = id;
        }

        public static void DeactivatePowerUp(this ICommandBuffer commandBuffer, Uid powerUpUid)
        {
            ref var command = ref commandBuffer.Create<DeactivatePowerUpCommand>();
            command.PowerUpUid = powerUpUid;
        }

        public static void PointerDown(this ICommandBuffer commandBuffer, Int32 touchId)
        {
            ref var command = ref commandBuffer.Create<PointerDownCommand>();
            command.TouchId = touchId;
        }

        public static void PointerDrag(this ICommandBuffer commandBuffer, Int32 touchId, Vector3 delta)
        {
            ref var command = ref commandBuffer.Create<PointerDragCommand>();
            command.TouchId = touchId;
            command.Delta = delta;
        }

        public static void PointerUp(this ICommandBuffer commandBuffer, Int32 touchId)
        {
            ref var command = ref commandBuffer.Create<PointerUpCommand>();
            command.TouchId = touchId;
        }

        public static void AddCoins(this ICommandBuffer commandBuffer, Int32 value, Boolean isPlayer)
        {
            ref var command = ref commandBuffer.Create<AddCoinsCommand>();
            command.Value = value;
            command.IsPlayer = isPlayer;
        }

        public static void CompletePerformingAttack(this ICommandBuffer commandBuffer, Uid attackerUid)
        {
            ref var command = ref commandBuffer.Create<CompletePerformingAttackCommand>();
            command.AttackerUid = attackerUid;
        }

        public static void DestroyProjectile(this ICommandBuffer commandBuffer, Int32 projectileHash)
        {
            ref var command = ref commandBuffer.Create<DestroyProjectileCommand>();
            command.ProjectileHash = projectileHash;
        }

        public static void PerformAttack(this ICommandBuffer commandBuffer, Uid attacker)
        {
            ref var command = ref commandBuffer.Create<PerformAttackCommand>();
            command.Attacker = attacker;
        }

        public static void PlayerBasicAttack(this ICommandBuffer commandBuffer)
        {
            ref var command = ref commandBuffer.Create<PlayerBasicAttackCommand>();
        }

        public static void StartPerformingAttack(this ICommandBuffer commandBuffer, Uid attacker)
        {
            ref var command = ref commandBuffer.Create<StartPerformingAttackCommand>();
            command.Attacker = attacker;
        }

        public static void TakeDamageByWeapon(this ICommandBuffer commandBuffer, Int32 weaponHash, Int32 targetHash)
        {
            ref var command = ref commandBuffer.Create<TakeDamageByWeaponCommand>();
            command.WeaponHash = weaponHash;
            command.TargetHash = targetHash;
        }

        public static void RecalculateUnitAttributes(this ICommandBuffer commandBuffer, Uid unitUid)
        {
            ref var command = ref commandBuffer.Create<RecalculateUnitAttributesCommand>();
            command.UnitUid = unitUid;
        }
    }
}

