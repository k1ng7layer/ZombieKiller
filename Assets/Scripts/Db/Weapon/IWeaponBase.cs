namespace Db.Weapon
{
    public interface IWeaponBase
    {
        WeaponSettings GetWeapon(string weaponName);
    }
}