using Ecs.Commands.Command.Combat;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Commands.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 300, nameof(EFeatures.Combat))]
    public class CompletePerformingAttackSystem : ForEachCommandUpdateSystem<CompletePerformingAttackCommand>
    {
        private readonly GameContext _game;

        public CompletePerformingAttackSystem
        (ICommandBuffer commandBuffer, 
            GameContext game) : base(commandBuffer)
        {
            _game = game;
        }

        protected override void Execute(ref CompletePerformingAttackCommand command)
        {
            var attacker = _game.GetEntityWithUid(command.AttackerUid);

            attacker.IsPerformingAttack = false;
            
            var weaponUid = attacker.EquippedWeapon.Value.WeaponEntityUid;
            var weaponEntity = _game.GetEntityWithUid(weaponUid);
            weaponEntity.IsPerformingAttack = false;
            weaponEntity.AttackTargets.Value.Clear();
            
            Debug.Log($"CompletePerformingAttackSystem");
        }
    }
}