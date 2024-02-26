namespace Db.Items.Repositories
{
    public interface IWeaponRepository
    {
        Items.Impl.Weapon GetWeapon(string weaponId);
    }
}