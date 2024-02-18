using Ecs.Commands.Generator;

namespace Ecs.Commands.Command.Combat
{
    [Command]
    public struct TakeDamageByWeaponCommand
    {
        public int WeaponHash;
        public int TargetHash;
    }
}