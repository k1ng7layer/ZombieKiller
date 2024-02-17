using Game.Utils;

namespace Db.Player
{
    public interface IPlayerSettings
    {
        float BaseMoveSpeed { get; }
        EWeaponId StarterWeapon { get; }
    }
}