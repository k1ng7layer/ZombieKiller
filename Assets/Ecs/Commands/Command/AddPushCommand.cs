using Ecs.Commands.Generator;
using Ecs.Extensions.UidGenerator;
using UnityEngine;

namespace Ecs.Commands.Command
{
    [Command]
    public struct AddPushCommand
    {
        public Uid Unit;
        public Vector3 Direction;
        public float Force;
    }
}