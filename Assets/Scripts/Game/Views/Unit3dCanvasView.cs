using Game.Providers.CameraProvider;
using UnityEngine;
using Zenject;

namespace Game.Views
{
    public class Unit3dCanvasView : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [Inject] private ICameraProvider _cameraProvider;
        
        private Camera _camera;

        private void Start()
        {
            _camera = _cameraProvider.GetCamera();
        }

        private void Update()
        {
            if(_camera == null)
                return;
            
            var rotation = _camera.transform.rotation;
            canvas.transform.LookAt(canvas.transform.position + rotation * Vector3.forward, rotation * Vector3.up);
        }
    }
}