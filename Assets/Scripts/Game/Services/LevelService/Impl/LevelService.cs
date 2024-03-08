using Db.Level;
using UnityEngine;

namespace Game.Services.LevelService.Impl
{
    public class LevelService : ILevelService
    {
        private readonly ILevelSettingsBase _levelSettingsBase;
        private const string CURRENT_LEVEL_KEY = "LevelNumberKey";

        public LevelService(ILevelSettingsBase levelSettingsBase)
        {
            _levelSettingsBase = levelSettingsBase;

            CurrentLevel = PlayerPrefs.GetInt(CURRENT_LEVEL_KEY, 0);
        }

        public int CurrentLevel { get; private set; }
        
        public int GetNextLevel()
        {
            if (_levelSettingsBase.LevelList.Count - 1 == CurrentLevel)
                return CurrentLevel;

            return CurrentLevel + 1;
        }

        public void SetCurrentLevel(int levelId)
        {
            CurrentLevel = levelId;
            PlayerPrefs.SetInt(CURRENT_LEVEL_KEY, levelId);
            PlayerPrefs.Save();
        }

        public string GetLevelSceneName(int levelId)
        {
            return _levelSettingsBase.LevelList[CurrentLevel].SceneName;
        }
    }
}