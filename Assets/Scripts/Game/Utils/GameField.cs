using Ecs.Views.Linkable.Impl.Building;
using UnityEngine;

namespace Game.Utils
{
    public class GameField : MonoBehaviour
    {
        [SerializeField] private Transform startCameraPosition;
        
        public Transform StartCameraPosition => startCameraPosition;
    }
}