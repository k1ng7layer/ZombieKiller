using Ecs.Commands.Generator;
using Game.Utils;
using UnityEngine;

namespace Ecs.Commands.Systems.Spawn
{
    [Command]
    public struct SpawnEnemyCommand
    {
        public EEnemyType EnemyType;
        public Vector3 Position;
        public Quaternion Rotation;
    }
}