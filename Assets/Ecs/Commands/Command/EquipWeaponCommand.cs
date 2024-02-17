using Ecs.Commands.Generator;
using Ecs.Extensions.UidGenerator;
using Game.Utils;

namespace Ecs.Commands.Command
{
    [Command]
    public struct EquipWeaponCommand
    {
        public EWeaponId WeaponId;
        public Uid Owner;
    }
}