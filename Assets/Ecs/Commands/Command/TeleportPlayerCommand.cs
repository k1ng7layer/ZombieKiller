using Ecs.Commands.Generator;

namespace Ecs.Commands.Command
{
    [Command]
    public struct TeleportPlayerCommand
    {
        public int PortalHash;
    }
}