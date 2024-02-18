using Ecs.Commands.Generator;

namespace Ecs.Commands.Command.Combat
{
    [Command]
    public struct DestroyProjectileCommand
    {
        public int ProjectileHash;
    }
}