using Game.Ui.Loading;
using SimpleUi;

namespace Game.Ui.Windows
{
    public class ProjectWindow : WindowBase
    {
        public override string Name => "ProjectWindow";
        
        protected override void AddControllers()
        {
            AddController<LoadingController>();
        }
    }
}