using Ecs.Extensions.UidGenerator;
using Game.Utils;

namespace Ecs.Utils
{
    public readonly struct EquippedWeaponInfo
    {
        public readonly EWeaponId Id;
        public readonly Uid WeaponEntityUid;

        public EquippedWeaponInfo(EWeaponId id, Uid weaponEntityUid)
        {
            Id = id;
            WeaponEntityUid = weaponEntityUid;
        }
    }
}