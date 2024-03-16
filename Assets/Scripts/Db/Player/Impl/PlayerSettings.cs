using UnityEngine;

namespace Db.Player.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PlayerSettings), fileName = nameof(PlayerSettings))]
    public class PlayerSettings : ScriptableObject, IPlayerSettings
    {
        [SerializeField] private string _starterWeapon;
        [SerializeField] private float _baseMoveSpeed;
        [SerializeField] private float _levelExpMultiplier = 1.3f;
        [SerializeField] private float _levelRequiredMultiplier = 1.5f;
        [SerializeField] private float _baseExperienceRequired = 100f;
        [SerializeField] private float _baseMaxHealth = 100f;
        [SerializeField] private float _baseAttackSpeed = 1.7f;
        [SerializeField] private float _collectItemsDist = 1f;
        [SerializeField] private float _rotateDistToEnemy = 4f;

        public float BaseMoveSpeed => _baseMoveSpeed;
        public float LevelGainExpMultiplier => _levelExpMultiplier;
        public float LevelRequiredExpMultiplier => _levelRequiredMultiplier;
        public float BaseExperienceRequired => _baseExperienceRequired;
        public string StarterWeapon => _starterWeapon;
        public float BaseMaxHealth => _baseMaxHealth;
        public float BaseAttackSpeed => _baseAttackSpeed;
        public float CollectItemsDist => _collectItemsDist = 1f;

        public float RotateDistToEnemy => _rotateDistToEnemy;
    }
}