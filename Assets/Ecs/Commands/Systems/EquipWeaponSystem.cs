using Db.Items.Repositories;
using Ecs.Commands.Command;
using Ecs.Game.Extensions;
using Ecs.Utils;
using Ecs.Utils.LinkedEntityRepository;
using Ecs.Views.Linkable.Impl;
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
        private readonly ILinkedEntityRepository _linkedEntityRepository;
        private readonly GameContext _game;

        public EquipWeaponSystem(
            ICommandBuffer commandBuffer,
            IWeaponRepository weaponRepository,
            ILinkedEntityRepository linkedEntityRepository,
            GameContext game
        ) : base(commandBuffer)
        {
            _commandBuffer = commandBuffer;
            _weaponRepository = weaponRepository;
            _linkedEntityRepository = linkedEntityRepository;
            _game = game;
        }

        protected override void Execute(ref EquipWeaponCommand command)
        {
            var weaponSettings = _weaponRepository.GetWeapon(command.WeaponId);
            var owner = _game.GetEntityWithUid(command.Owner);
            var weaponEntity = _game.CreateWeapon(command.WeaponId, weaponSettings, owner.Uid.Value, command.Spawn);
            
            if (owner.HasEquippedWeapon && owner.EquippedWeapon.Value.Id != string.Empty)
            {
                var currentWeapon = _game.GetEntityWithUid(owner.EquippedWeapon.Value.WeaponEntityUid);
                currentWeapon.IsDestroyed = true;
            }
            
            var weaponUid = weaponEntity.Uid.Value;
            owner.ReplaceEquippedWeapon(new EquippedWeaponInfo(command.WeaponId, weaponUid));
            
            if (command.Spawn)
            {
                _commandBuffer.AttachWeapon(weaponUid, owner.WeaponRoot.Value);
            }
            else
            {
                var view = (UnitView)owner.Link.View;
                view.Weapon.Link(weaponEntity);
                weaponEntity.AddLink(view.Weapon);
                _linkedEntityRepository.Add(view.Weapon.transform.GetHashCode(), weaponEntity);
            }
        }
    }
}