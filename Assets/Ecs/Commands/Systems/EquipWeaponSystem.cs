using System.Collections.Generic;
using Db.Weapon;
using Ecs.Commands.Command;
using Ecs.Extensions.UidGenerator;
using Ecs.Utils;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 500, nameof(EFeatures.Combat))]
    public class EquipWeaponSystem : ForEachCommandUpdateSystem<EquipWeaponCommand>
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly IWeaponBase _weaponBase;
        private readonly GameContext _game;

        public EquipWeaponSystem(
            ICommandBuffer commandBuffer,
            IWeaponBase weaponBase,
            GameContext game
        ) : base(commandBuffer)
        {
            _commandBuffer = commandBuffer;
            _weaponBase = weaponBase;
            _game = game;
        }

        protected override void Execute(ref EquipWeaponCommand command)
        {
            var weaponEntity = _game.CreateEntity();
            var weaponUid = UidGenerator.Next();
            var owner = _game.GetEntityWithUid(command.Owner);
            var weaponParams = _weaponBase.GetWeapon(command.WeaponId);
            
            if (owner.HasEquippedWeapon && owner.EquippedWeapon.Value.Id != EWeaponId.None)
            {
                var currentWeapon = _game.GetEntityWithUid(owner.EquippedWeapon.Value.WeaponEntityUid);
                currentWeapon.IsDestroyed = true;
            }
            
            weaponEntity.AddUid(weaponUid);
            weaponEntity.AddWeapon(command.WeaponId);
            weaponEntity.AddOwner(command.Owner);
            weaponEntity.AddPrefab(command.WeaponId.ToString());
            weaponEntity.AddAttackTargets(new HashSet<Uid>());
            owner.ReplaceEquippedWeapon(new EquippedWeaponInfo(command.WeaponId, weaponUid));
            weaponEntity.AddPhysicalDamage(weaponParams.PhysicalDamage);
            weaponEntity.AddMagicDamage(weaponParams.MagicDamage);
            
            weaponEntity.IsInstantiate = true;
            
            _commandBuffer.AttachWeapon(weaponUid, owner.WeaponRoot.Value);
        }
    }
}