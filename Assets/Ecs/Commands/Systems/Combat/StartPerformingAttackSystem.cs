using Ecs.Commands.Command.Combat;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Commands.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 100, nameof(EFeatures.Combat))]
    public class StartPerformingAttackSystem : ForEachCommandUpdateSystem<StartPerformingAttackCommand>
    {
        private readonly GameContext _game;

        public StartPerformingAttackSystem(ICommandBuffer commandBuffer, GameContext game) : base(commandBuffer)
        {
            _game = game;
        }

        protected override void Execute(ref StartPerformingAttackCommand command)
        {
            var attacker = _game.GetEntityWithUid(command.Attacker);
            
            if (attacker.IsPerformingAttack)
                return;
            
            Debug.Log($"StartPerformingAttackSystem");
            attacker.IsPerformingAttack = true;
        }
    }
}