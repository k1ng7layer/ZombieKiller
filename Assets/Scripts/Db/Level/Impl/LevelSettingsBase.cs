using System.Collections.Generic;
using UnityEngine;

namespace Db.Level.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(LevelSettingsBase), fileName = "LevelSettingsBase")]
    public class LevelSettingsBase : ScriptableObject, ILevelSettingsBase
    {
        [SerializeField] private List<LevelParams> levelParams;

        public IReadOnlyList<LevelParams> LevelList => levelParams;
    }
}