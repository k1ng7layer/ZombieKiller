using Game.Providers.GameFieldProvider;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Initialize
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 50, nameof(EFeatures.Initialization))]
    public class InitializePlayerSystem : IInitializeSystem
    {
        private readonly IGameFieldProvider _gameFieldProvider;
        private readonly GameContext _game;

        public InitializePlayerSystem(
            IGameFieldProvider gameFieldProvider, 
            GameContext game
        )
        {
            _gameFieldProvider = gameFieldProvider;
            _game = game;
        }
        
        public void Initialize()
        {
            var playerView = _gameFieldProvider.GameField.PlayerView;
            var player = _game.CreateEntity();
            player.IsPlayer = true;
            player.IsCanMove = true;
            
            player.AddRotation(playerView.transform.rotation);
            
            playerView.Link(player);
        }
    }
}