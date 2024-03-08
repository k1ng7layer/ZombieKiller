using SimpleUi.Abstracts;
using UnityEngine.UI;

namespace Game.Ui.Inventory
{
    public class InventoryItemView : UiView
    {
        public string ItemId;
        public Image Icon;
        public Button Btn;
        public Image Selected;

        public void ResetView()
        {
            Icon.sprite = null;
        }
    }
}