using Ecs.Commands.Generator;
using Ecs.Extensions.UidGenerator;
using Game.Utils;
using UnityEngine;

namespace Ecs.Commands.Command.Combat
{
    [Command]
    public struct CreateExplosionCommand
    {
        public Vector3 Origin;
        public EExplosionType ExplosionType;
        public Uid Owner;
        public float Radius;
        public float Damage;
    }
}