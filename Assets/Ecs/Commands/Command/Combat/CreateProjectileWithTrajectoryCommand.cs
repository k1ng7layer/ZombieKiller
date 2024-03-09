using Ecs.Commands.Generator;
using Ecs.Extensions.UidGenerator;
using Game.Utils;
using UnityEngine;

namespace Ecs.Commands.Command.Combat
{
    [Command]
    public struct CreateProjectileWithTrajectoryCommand
    {
        public Uid Shooter;
        public Vector3 Origin;
        public Vector3[] Trajectory;
        public EProjectileType ProjectileType;
        public float Speed;
    }
}