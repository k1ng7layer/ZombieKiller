using Ecs.Utils.Interfaces;
using Game.Providers.PowerUpProvider;
using Game.Ui.Utils;
using UniRx;

namespace Game.Ui.PlayerStats.LevelUp
{
    public class LevelUpController : UiManagedController<LevelUpView>, 
        IUiInitialize
    {
        private readonly GameContext _game;
        private readonly IPowerUpProvider _powerUpProvider;

        public LevelUpController(
            GameContext game, 
            IPowerUpProvider powerUpProvider
        )
        {
            _game = game;
            _powerUpProvider = powerUpProvider;
        }
        
        public void Initialize()
        {
            var player = _game.PlayerEntity;
            
            player.SubscribeUnitLevel((_, value) => OnUnitLevelChanged(value)).AddTo(View);
        }

        public override void OnHide()
        {
            View.PowerUpElementCollection.Clear();
        }

        private void OnUnitLevelChanged(int level)
        {
            if (level == 1)
                return;

            for (int i = 0; i < 3; i++)
            {
                var powerUpSettings = _powerUpProvider.Get();
                var powerUp = View.PowerUpElementCollection.Create();
                
                powerUp.SetInfo(
                    powerUpSettings.Icon, 
                    powerUpSettings.Name, 
                    powerUpSettings.Description);
            }
        }
    }
}