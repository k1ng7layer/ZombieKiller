using Ecs.Commands.Generator;

namespace Ecs.Commands.Command.Combat
{
    [Command]
    public struct TakeDamageCommand
    {
        public int WeaponHash;
        public int TargetHash;
    }
}