using Ecs.Commands.Generator;
using Ecs.Extensions.UidGenerator;

namespace Ecs.Commands.Command.Combat
{
    [Command]
    public struct StartPerformingAttackCommand
    {
        public Uid Attacker;
    }
}