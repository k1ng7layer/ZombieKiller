using Ecs.Utils;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestCube : MonoBehaviour
    {
        [SerializeField] private Collider _collider;

        private void Start()
        {
            _collider.OnTriggerEnterAsObservable().Subscribe(other =>
            {
                
                if (LayerMask.GetMask(LayerNames.Weapon) == (LayerMask.GetMask(LayerNames.Weapon) 
                                                             | 1 << other.gameObject.layer))
                {
                    var weaponHash = other.transform.GetHashCode();
                    Debug.Log($"TestCube trigger");
                    
                }
            }).AddTo(gameObject);
        }
    }
}