using UnityEngine;

namespace Db.LootParams
{
    [CreateAssetMenu(menuName = "Settings/Items/" + nameof(LootPreset), fileName = "LootPreset")]
    public class LootPreset : ScriptableObject
    {
        public LootParams[] LootPresets;
    }
}