using Ecs.Commands.Generator;
using Ecs.Extensions.UidGenerator;
using UnityEngine;

namespace Ecs.Commands.Command.Abilities
{
    [Command]
    public struct CastArtilleryShotAbilityCommand
    {
        public Uid Owner;
        public Vector3 Origin;
        public Vector3 Target;
    }
}