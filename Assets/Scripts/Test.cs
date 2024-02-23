using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private Button btn;
        
        private UnityAction _onClickListener;
        
        private void Start()
        {
            _onClickListener = () =>
            {
                DoSmth(1, 2, string.Empty);
            };
            
            btn.onClick.AddListener(_onClickListener);
        }

        private void OnDestroy()
        {
            btn.onClick.RemoveListener(_onClickListener);
        }

        private void DoSmth(int a, int b, string text)
        {
            
        }
        
    }
}