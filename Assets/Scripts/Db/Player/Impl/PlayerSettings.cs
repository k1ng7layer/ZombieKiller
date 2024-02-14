using UnityEngine;

namespace Db.Player.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PlayerSettings), fileName = nameof(PlayerSettings))]
    public class PlayerSettings : ScriptableObject, IPlayerSettings
    {
        [SerializeField] private float _baseMoveSpeed;

        public float BaseMoveSpeed => _baseMoveSpeed;
    }
}