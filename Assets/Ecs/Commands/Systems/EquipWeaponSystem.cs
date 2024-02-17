using Db.Weapon;
using Ecs.Commands.Command;
using Ecs.Game.Extensions;
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
            var weaponSettings = _weaponBase.GetWeapon(command.WeaponId);
            var owner = _game.GetEntityWithUid(command.Owner);
            var weaponEntity = _game.CreateWeapon(command.WeaponId, weaponSettings, owner.Uid.Value);
            
            if (owner.HasEquippedWeapon && owner.EquippedWeapon.Value.Id != EWeaponId.None)
            {
                var currentWeapon = _game.GetEntityWithUid(owner.EquippedWeapon.Value.WeaponEntityUid);
                currentWeapon.IsDestroyed = true;
            }

            var weaponUid = weaponEntity.Uid.Value;
            owner.ReplaceEquippedWeapon(new EquippedWeaponInfo(command.WeaponId, weaponUid));
            
            _commandBuffer.AttachWeapon(weaponUid, owner.WeaponRoot.Value);
        }
    }
}