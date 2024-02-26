namespace Db.Player
{
    public interface IPlayerSettings
    {
        float BaseMoveSpeed { get; }
        float LevelGainExpMultiplier { get; }
        float LevelRequiredExpMultiplier { get; }
        float BaseExperienceRequired { get; }
        string StarterWeapon { get; }
        float BaseMaxHealth { get; }
        float BaseAttackSpeed { get; }
        float CollectItemsDist { get; }
    }
}