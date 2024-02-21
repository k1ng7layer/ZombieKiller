using Ecs.Commands.Generator;
using Ecs.Extensions.UidGenerator;

namespace Ecs.Commands.Command.PowerUp
{
    [Command]
    public struct DeactivatePowerUpCommand
    {
        public Uid PowerUpUid;
    }
}