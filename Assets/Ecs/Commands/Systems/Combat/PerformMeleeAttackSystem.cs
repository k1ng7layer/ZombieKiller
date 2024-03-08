using Db.Items.Repositories;
using Ecs.Commands.Command.Combat;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 200, nameof(EFeatures.Combat))]
    public class PerformMeleeAttackSystem : ForEachCommandUpdateSystem<PerformAttackCommand>
    {
        private readonly IWeaponRepository _weaponRepository;
        private readonly GameContext _game;
        
        public PerformMeleeAttackSystem(
            ICommandBuffer commandBuffer, 
            IWeaponRepository weaponRepository, 
            GameContext game) : base(commandBuffer)
        {
            _weaponRepository = weaponRepository;
            _game = game;
        }
        
        protected override bool CleanUp => false;

        protected override void Execute(ref PerformAttackCommand command)
        {
            var attacker = _game.GetEntityWithUid(command.Attacker);
            
            // if (attacker.IsPerformingAttack)
            //     return;
            
            var weaponId = attacker.EquippedWeapon.Value.Id;
            
            var weapon = _weaponRepository.GetWeapon(weaponId);
            
            if (weapon.WeaponType != EWeaponType.Melee)
                return;
            
            // attacker.IsPerformingAttack = true;
            var weaponUid = attacker.EquippedWeapon.Value.WeaponEntityUid;
            var weaponEntity = _game.GetEntityWithUid(weaponUid);
            weaponEntity.IsPerformingAttack = true;
        }
    }
}