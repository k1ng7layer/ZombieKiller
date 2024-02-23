using SimpleUi;
using SimpleUi.Interfaces;

namespace Game.Ui.PlayerStats.LevelUp
{
    public class LevelUpWindow : WindowBase, IPopUp
    {
        public override string Name => "LevelUp";
        
        protected override void AddControllers()
        {
            AddController<LevelUpController>();
        }
    }
}