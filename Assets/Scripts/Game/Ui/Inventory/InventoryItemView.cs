using SimpleUi.Abstracts;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game.Ui.Inventory
{
    public class InventoryItemView : UiView
    {
        public int ItemId;
        public Image Icon;
        public Button Btn;
        public Image Selected;
    }
}