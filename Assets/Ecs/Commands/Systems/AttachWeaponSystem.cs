using Ecs.Commands.Command;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 450, nameof(EFeatures.Combat))]
    public class AttachWeaponSystem : ForEachCommandUpdateSystem<AttachWeaponCommand>
    {
        private readonly GameContext _game;

        public AttachWeaponSystem(
            ICommandBuffer commandBuffer, 
            GameContext game
        ) : base(commandBuffer)
        {
            _game = game;
        }

        protected override void Execute(ref AttachWeaponCommand command)
        {
            var weapon = _game.GetEntityWithUid(command.Weapon);
            weapon.ReplaceParentTransform(command.Transform);
        }
    }
}