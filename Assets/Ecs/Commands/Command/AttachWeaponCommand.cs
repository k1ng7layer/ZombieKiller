using Ecs.Commands.Generator;
using Ecs.Extensions.UidGenerator;
using UnityEngine;

namespace Ecs.Commands.Command
{
    [Command]
    public struct AttachWeaponCommand
    {
        public Uid Weapon;
        public Transform Transform;
    }
}