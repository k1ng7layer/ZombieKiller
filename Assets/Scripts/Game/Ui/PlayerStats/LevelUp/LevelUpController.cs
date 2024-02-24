using Db.PowerUps;
using Ecs.Commands;
using Ecs.Utils.Interfaces;
using Game.Providers.PowerUpProvider;
using Game.Ui.Utils;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Game.Ui.PlayerStats.LevelUp
{
    public class LevelUpController : UiManagedController<LevelUpView>, 
        IUiInitialize
    {
        private readonly GameContext _game;
        private readonly IPowerUpIdProvider _powerUpIdProvider;
        private readonly ICommandBuffer _commandBuffer;
        private readonly IPowerUpBase _powerUpBase;
        private readonly SignalBus _signalBus;

        public LevelUpController(
            GameContext game, 
            IPowerUpIdProvider powerUpIdProvider,
            ICommandBuffer commandBuffer,
            IPowerUpBase powerUpBase,
            SignalBus signalBus
        )
        {
            _game = game;
            _powerUpIdProvider = powerUpIdProvider;
            _commandBuffer = commandBuffer;
            _powerUpBase = powerUpBase;
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            var player = _game.PlayerEntity;
            
            player.SubscribeUnitLevel(OnUnitLevelChanged).AddTo(View);
        }

        public override void OnHide()
        {
            View.PowerUpElementCollection.Clear();
        }

        private void OnUnitLevelChanged(GameEntity player, int level)
        {
            if (level == 1)
                return;

            for (int i = 0; i < 3; i++)
            {
                var powerUpId = _powerUpIdProvider.Get();
                var elementView = View.PowerUpElementCollection.Create();
                var powerUpSettings = _powerUpBase.PowerUpS[powerUpId];
                
                elementView.SetInfo(
                    powerUpId,
                    powerUpSettings.Icon, 
                    powerUpSettings.Name, 
                    powerUpSettings.Description);

                elementView.PickButton.OnClickAsObservable().Subscribe(_ =>
                {
                    _commandBuffer.CreatePowerUp(_game.PlayerEntity.Uid.Value, powerUpId);
                    
                    _signalBus.BackWindow();
                    
                    player.IsCanMove = true;
                    _commandBuffer.SetGameState(EGameState.Game);
                });
            }
        }
    }
}