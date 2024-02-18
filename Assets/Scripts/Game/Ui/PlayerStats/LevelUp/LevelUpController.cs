using Ecs.Utils.Interfaces;
using Game.Ui.Utils;
using UniRx;

namespace Game.Ui.PlayerStats.LevelUp
{
    public class LevelUpController : UiManagedController<LevelUpView>, 
        IUiInitialize
    {
        private readonly GameContext _game;

        public LevelUpController(GameContext game)
        {
            _game = game;
        }
        
        public void Initialize()
        {
            var player = _game.PlayerEntity;
            
            player.SubscribeUnitLevel((_, value) => OnUnitLevelChanged(value)).AddTo(_disposables);
        }

        public override void OnHide()
        {
            View.PowerUpElementCollection.Clear();
        }

        private void OnUnitLevelChanged(int level)
        {
            var powerUp = View.PowerUpElementCollection.Create();
        }
    }
}