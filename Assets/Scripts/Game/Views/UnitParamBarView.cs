using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public class UnitParamBarView : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        public void SetValue(float value)
        {
            slider.value = value;
        }
    }
}