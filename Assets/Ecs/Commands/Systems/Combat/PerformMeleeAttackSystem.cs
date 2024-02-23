using Db.Weapon;
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
        private readonly IWeaponBase _weaponBase;
        private readonly GameContext _game;
        
        public PerformMeleeAttackSystem(
            ICommandBuffer commandBuffer, 
            IWeaponBase weaponBase, 
            GameContext game) : base(commandBuffer)
        {
            _weaponBase = weaponBase;
            _game = game;
        }
        
        protected override bool CleanUp => false;

        protected override void Execute(ref PerformAttackCommand command)
        {
            var attacker = _game.GetEntityWithUid(command.Attacker);
            
            // if (attacker.IsPerformingAttack)
            //     return;
            
            var weaponId = attacker.EquippedWeapon.Value.Id;
            
            var weapon = _weaponBase.GetWeapon(weaponId);
            
            if (weapon.WeaponType != EWeaponType.Melee)
                return;
            
            attacker.IsPerformingAttack = true;
            var weaponUid = attacker.EquippedWeapon.Value.WeaponEntityUid;
            var weaponEntity = _game.GetEntityWithUid(weaponUid);
            weaponEntity.IsPerformingAttack = true;
        }
    }
}