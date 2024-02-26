using Ecs.Extensions.UidGenerator;

namespace Ecs.Utils
{
    public readonly struct EquippedWeaponInfo
    {
        public readonly string Id;
        public readonly Uid WeaponEntityUid;

        public EquippedWeaponInfo(string id, Uid weaponEntityUid)
        {
            Id = id;
            WeaponEntityUid = weaponEntityUid;
        }
    }
}