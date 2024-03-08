using Ecs.Commands.Command;
using Game.Ui.PlayerStats.LevelUp;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using SimpleUi.Signals;
using Zenject;

namespace Ecs.Commands.Systems
{
    public class LevelUpSystem : ForEachCommandUpdateSystem<LevelUpCommand>
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly GameContext _game;
        private readonly SignalBus _signalBus;

        public LevelUpSystem(
            ICommandBuffer commandBuffer, 
            GameContext game, 
            SignalBus signalBus
        ) : base(commandBuffer)
        {
            _commandBuffer = commandBuffer;
            _game = game;
            _signalBus = signalBus;
        }

        protected override void Execute(ref LevelUpCommand command)
        {
            var player = _game.PlayerEntity;
            var currentLevel = player.UnitLevel.Value;
            player.ReplaceUnitLevel(currentLevel + 1);
            player.IsCanMove = false;
            _signalBus.OpenWindow<LevelUpWindow>();
            _commandBuffer.SetGameState(EGameState.Pause);
        }
    }
}