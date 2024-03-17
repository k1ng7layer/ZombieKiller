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
            ItemId = string.Empty;
            Icon.sprite = null;
            Icon.gameObject.SetActive(false);
        }
    }
}