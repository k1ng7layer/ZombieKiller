using SimpleUi;
using SimpleUi.Interfaces;

namespace Game.Ui.Inventory
{
    public class PlayerBagInventoryWindow : WindowBase, IPopUp
    {
        public override string Name => "PlayerBagInventory";

        protected override void AddControllers()
        {
            AddController<PlayerBagInventoryController>();
        }
    }
}