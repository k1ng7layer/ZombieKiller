using Ecs.Commands.Generator;
using Ecs.Extensions.UidGenerator;

namespace Ecs.Commands.Command.Combat
{
    [Command]
    public struct CompletePerformingAttackCommand
    {
        public Uid AttackerUid;
    }
}