using SimpleUi.Abstracts;
using UnityEngine.UI;

namespace Game.Ui.Inventory
{
    public class PlayerBagInventoryView : UiView
    {
        public Button BackButton;
        public InventoryItemInfoPopupView InfoPopupView;
        public InventoryItemListCollection ItemListCollection;
    }
}