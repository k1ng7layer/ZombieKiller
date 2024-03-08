using Ecs.Commands.Generator;
using Game.Utils;

namespace Ecs.Commands.Command
{
    [Command]
    public struct DropItemCommand
    {
        public CollectableInfo Info;
    }
}