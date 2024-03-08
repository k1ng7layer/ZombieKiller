using Ecs.Commands.Generator;
using Ecs.Extensions.UidGenerator;

namespace Ecs.Commands.Command
{
    [Command]
    public struct EquipWeaponCommand
    {
        public string WeaponId;
        public Uid Owner;
        public bool Spawn;
    }
}