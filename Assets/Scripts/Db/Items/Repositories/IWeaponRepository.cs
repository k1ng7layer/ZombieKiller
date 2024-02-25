using Game.Utils;

namespace Db.Items.Repositories
{
    public interface IWeaponRepository
    {
        Items.Impl.Weapon GetWeapon(EWeaponId weaponId);
    }
}