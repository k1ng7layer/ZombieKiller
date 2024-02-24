using Ecs.Commands.Generator;
using Ecs.Extensions.UidGenerator;

namespace Ecs.Commands.Command.PowerUp
{
    [Command]
    public struct CreatePowerUpCommand
    {
        public Uid Owner;
        public int Id;
    }
}