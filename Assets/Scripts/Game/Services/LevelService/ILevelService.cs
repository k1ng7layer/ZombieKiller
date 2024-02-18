namespace Game.Services.LevelService
{
    public interface ILevelService
    {
        int CurrentLevel { get; }
        int GetNextLevel();
        void SetCurrentLevel(int levelId);
        string GetLevelSceneName(int levelId);
    }
}