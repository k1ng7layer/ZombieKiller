using UnityEngine;

namespace Db.Loot.Impl
{
    [CreateAssetMenu(menuName = "Settings/Loot/" + nameof(LootSettings), fileName = "LootSettings")]
    public class LootSettings : ScriptableObject, ILootSettings
    {
        [SerializeField] private float _initialVelocityMultiplier = 7f;
        [SerializeField] private float _gravity = 9.81f;

        public float InitialVelocityMultiplier => _initialVelocityMultiplier;

        public float Gravity => _gravity;
    }
}