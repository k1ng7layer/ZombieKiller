using System;
using System.Collections.Generic;

namespace Db.Level
{
    public interface ILevelSettingsBase
    {
        IReadOnlyList<LevelParams> LevelList { get; }
    }

    [Serializable]
    public class LevelParams
    {
        public string SceneName;
        public string DisplayName;
    }
}