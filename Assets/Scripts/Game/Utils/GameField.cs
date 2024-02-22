
using Ecs.Views.Linkable.Impl;
using Ecs.Views.Linkable.Impl.Camera;
using Ecs.Views.Linkable.Impl.Portals;
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
        [SerializeField] private PortalView[] levelPortals;
        
        public Transform StartCameraPosition => startCameraPosition;
        public VirtualCameraView VirtualCameraView => virtualCameraView;
        public PhysicalCameraView PhysicalCameraView => physicalCameraView;
        public PlayerView PlayerView => playerView;
        public Transform[] EnemySpawnPoints => enemySpawnPoints;
        public PortalView[] LevelPortals => levelPortals;
    }
}