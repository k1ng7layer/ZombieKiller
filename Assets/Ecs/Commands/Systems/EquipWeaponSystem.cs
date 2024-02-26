using Db.Items.Repositories;
using Ecs.Commands.Command;
using Ecs.Game.Extensions;
using Ecs.Utils;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 500, nameof(EFeatures.Combat))]
    public class EquipWeaponSystem : ForEachCommandUpdateSystem<EquipWeaponCommand>
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly IWeaponRepository _weaponRepository;
        private readonly GameContext _game;

        public EquipWeaponSystem(
            ICommandBuffer commandBuffer,
            IWeaponRepository weaponRepository,
            GameContext game
        ) : base(commandBuffer)
        {
            _commandBuffer = commandBuffer;
            _weaponRepository = weaponRepository;
            _game = game;
        }

        protected override void Execute(ref EquipWeaponCommand command)
        {
            var weaponSettings = _weaponRepository.GetWeapon(command.WeaponId);
            var owner = _game.GetEntityWithUid(command.Owner);
            var weaponEntity = _game.CreateWeapon(command.WeaponId, weaponSettings, owner.Uid.Value);
            
            if (owner.HasEquippedWeapon && owner.EquippedWeapon.Value.Id != string.Empty)
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