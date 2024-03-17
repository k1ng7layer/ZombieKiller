using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Ui.Inventory
{
    public class InventoryItemInfoPopupView : MonoBehaviour
    {
        public string ItemId;
        public Image Icon;
        public TextMeshProUGUI Description;
        public Image Background;
        public Button UseButton;
        public Button DropButton;
    }
}