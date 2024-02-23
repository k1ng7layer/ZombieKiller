using Db.Player;
using Ecs.Utils.Interfaces;
using Game.Ui.Utils;
using UniRx;
using UnityEngine;

namespace Game.Ui.PlayerStats.Exp
{
    public class PlayerExperienceController : UiManagedController<PlayerExperienceView>, 
        IUiInitialize
    {
        private readonly GameContext _game;
        private readonly IPlayerSettings _playerSettings;

        public PlayerExperienceController(GameContext game, IPlayerSettings playerSettings)
        {
            _game = game;
            _playerSettings = playerSettings;
        }
        
        public void Initialize()
        {
            var player = _game.PlayerEntity;
            
            player.SubscribeExperience(OnExperienceChanged).AddTo(View);
            player.SubscribeUnitLevel((_, value) => OnUnitLevelChanged(value)).AddTo(View);
        }
        
        private void OnExperienceChanged(GameEntity player, float exp)
        {
            var level = player.UnitLevel.Value;
            var expGoal = _playerSettings.LevelRequiredExpMultiplier * level * _playerSettings.BaseExperienceRequired;

            Debug.Log($"player exp gained: {exp}, goal: {expGoal}");
            View.Slider.value = exp / expGoal;
        }

        private void OnUnitLevelChanged(int level)
        {
             View.LevelText.text = $"{level}";
        }
    }
}