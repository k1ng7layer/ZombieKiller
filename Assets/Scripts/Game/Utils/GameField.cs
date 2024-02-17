
using Ecs.Views.Linkable.Impl;
using Ecs.Views.Linkable.Impl.Camera;
using UnityEngine;

namespace Game.Utils
{
    public class GameField : MonoBehaviour
    {
        [SerializeField] private VirtualCameraView virtualCameraView;
        [SerializeField] private PhysicalCameraView physicalCameraView;
        [SerializeField] private Transform startCameraPosition;
        [SerializeField] private PlayerView playerView;
        [SerializeField] private Transform[] enemySpawnPoints;
        
        public Transform StartCameraPosition => startCameraPosition;
        public VirtualCameraView VirtualCameraView => virtualCameraView;
        public PhysicalCameraView PhysicalCameraView => physicalCameraView;
        public PlayerView PlayerView => playerView;
        public Transform[] EnemySpawnPoints => enemySpawnPoints;
    }
}