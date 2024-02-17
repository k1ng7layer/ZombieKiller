using Db.Weapon;
using Ecs.Commands.Command.Combat;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 200, nameof(EFeatures.Combat))]
    public class PerformRangedAttackSystem : ForEachCommandUpdateSystem<PerformAttackCommand>
    {
        private readonly IWeaponBase _weaponBase;
        private readonly GameContext _game;

        public PerformRangedAttackSystem(
            ICommandBuffer commandBuffer, 
            IWeaponBase weaponBase, 
            GameContext game
        ) : base(commandBuffer)
        {
            _weaponBase = weaponBase;
            _game = game;
        }

        protected override void Execute(ref PerformAttackCommand command)
        {
            var attacker = _game.GetEntityWithUid(command.Attacker);
            
            var weaponId = attacker.EquippedWeapon.Value.Id;
            var weapon = _weaponBase.GetWeapon(weaponId);
            
            if (weapon.WeaponType != EWeaponType.Ranged)
                return;
            
            
            //attacker.IsPerformingAttack = true;
            
            //Spawn projectile here
        }
    }
}