using System.Collections.Generic;
using Db.PowerUps;
using Ecs.Extensions.UidGenerator;
using Ecs.Utils.Interfaces;
using SimpleUi.Abstracts;
using UniRx;

namespace Game.Ui.Buffs
{
    public class CurrentBuffsController : UiController<CurrentBuffsView>, IUiInitialize
    {
        private readonly PowerUpContext _powerUp;
        private readonly IPowerUpBase _powerUpBase;
        private readonly GameContext _game;
        private readonly Dictionary<Uid, CurrentBuffView> _currentBuffsViews = new();

        public CurrentBuffsController(PowerUpContext powerUp, IPowerUpBase powerUpBase, GameContext game)
        {
            _powerUp = powerUp;
            _powerUpBase = powerUpBase;
            _game = game;
        }
        
        public void Initialize()
        {
            _powerUp.PlayerPowerUpEntity.SubscribeAnyPlayerBuff(OnPlayerBuffed).AddTo(View);
            _powerUp.PlayerPowerUpEntity.SubscribeAnyPowerUpRemoved(OnPowerUpRemoved).AddTo(View);
        }

        private void OnPlayerBuffsChanged(GameEntity player, List<Uid> buffs)
        {
            var buffToRemove = new List<Uid>();
        }

        private void AddBuffView(Uid buffUid)
        {
            
        }

        private void RemoveBuff()
        {
            
        }

        private void OnPlayerBuffed(PowerUpEntity powerUpEntity)
        {
            var powerUpView = View.CurrentBuffsViewCollection.Create();
            var id = powerUpEntity.PowerUp.Id;
            var buffParams = _powerUpBase.Get(id);
            powerUpView.Icon.sprite = buffParams.Icon;
            
            _currentBuffsViews.Add(powerUpEntity.Uid.Value, powerUpView);
            
            powerUpEntity.SubscribeResource(((_, value) =>
            {
                OnPowerUpResourceChanged(powerUpView, value);
                
            })).AddTo(powerUpView);
        }

        private void OnPowerUpResourceChanged(CurrentBuffView currentBuffsView, float value)
        {
            currentBuffsView.TickText.text = $"{(int)value}";
        }

        private void OnPowerUpRemoved(PowerUpEntity powerUpEntity)
        {
            var view = _currentBuffsViews[powerUpEntity.Uid.Value];
            _currentBuffsViews.Remove(powerUpEntity.Uid.Value);
            View.CurrentBuffsViewCollection.Remove(view);
        }
    }
}