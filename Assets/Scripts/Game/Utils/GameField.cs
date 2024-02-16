
using Ecs.Views.Linkable.Impl;
using Ecs.Views.Linkable.Impl.Camera;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Utils
{
    public class GameField : MonoBehaviour
    {
        [SerializeField] private VirtualCameraView virtualCameraView;
        [SerializeField] private PhysicalCameraView physicalCameraView;
        [SerializeField] private Transform startCameraPosition;
        [FormerlySerializedAs("playerView")] [SerializeField] private UnitView unitView;
        
        public Transform StartCameraPosition => startCameraPosition;
        public VirtualCameraView VirtualCameraView => virtualCameraView;
        public PhysicalCameraView PhysicalCameraView => physicalCameraView;
        public UnitView UnitView => unitView;
    }
}