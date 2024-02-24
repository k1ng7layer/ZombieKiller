using Game.Utils;

namespace Db.Player
{
    public interface IPlayerSettings
    {
        float BaseMoveSpeed { get; }
        float LevelGainExpMultiplier { get; }
        float LevelRequiredExpMultiplier { get; }
        float BaseExperienceRequired { get; }
        EWeaponId StarterWeapon { get; }
        float BaseMaxHealth { get; }
        float BaseAttackSpeed { get; }
    }
}