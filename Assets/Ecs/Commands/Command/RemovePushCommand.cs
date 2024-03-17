using Ecs.Commands.Generator;
using Ecs.Extensions.UidGenerator;

namespace Ecs.Commands.Command
{
    [Command]
    public struct RemovePushCommand
    {
        public Uid Unit;
    }
}