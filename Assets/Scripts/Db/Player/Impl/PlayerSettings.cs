using Game.Utils;
using UnityEngine;

namespace Db.Player.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PlayerSettings), fileName = nameof(PlayerSettings))]
    public class PlayerSettings : ScriptableObject, IPlayerSettings
    {
        [SerializeField] private float _baseMoveSpeed;
        [SerializeField] private EWeaponId _starterWeapon;

        public float BaseMoveSpeed => _baseMoveSpeed;

        public EWeaponId StarterWeapon => _starterWeapon;
    }
}