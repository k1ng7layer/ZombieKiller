using Ecs.Utils.Interfaces;
using Game.Ui.Utils;
using UniRx;

namespace Game.Ui.PlayerStats.Health
{
    public class PlayerHealthController : UiManagedController<PlayerHealthView>, 
        IUiInitialize
    {
        private readonly GameContext _game;

        public PlayerHealthController(GameContext game)
        {
            _game = game;
        }
        
        public void Initialize()
        {
            var player = _game.PlayerEntity;

            player.SubscribeHealth(OnHealthChanged).AddTo(_disposables);
            player.SubscribeMaxHealth(OnMaxHealthChanged).AddTo(_disposables);
        }

        private void OnHealthChanged(GameEntity player, float health)
        {
            var maxHp = player.MaxHealth.Value;
            
            View.Slider.value = health / maxHp;
            View.TextValue.text = $"{health} / {maxHp}";
        }

        private void OnMaxHealthChanged(GameEntity player, float maxHp)
        {
            var currHealth = player.Health.Value;
            View.Slider.value = currHealth / maxHp;
            View.TextValue.text = $"{currHealth} / {maxHp}";
        }
    }
}