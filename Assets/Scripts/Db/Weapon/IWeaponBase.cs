using Game.Utils;

namespace Db.Weapon
{
    public interface IWeaponBase
    {
        WeaponSettings GetWeapon(EWeaponId weaponId);
    }
}