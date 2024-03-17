using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Player
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 1000, nameof(EFeatures.Input))]
    public class PlayerGravitySystem : IUpdateSystem
    {
        private readonly GameContext _game;

        public PlayerGravitySystem(GameContext game)
        {
            _game = game;
        }
        
        public void Update()
        {
            var player = _game.PlayerEntity;

            var dir = player.MoveDirection.Value;
            dir.y = -2f;
            
            player.ReplaceMoveDirection(dir);
        }
    }
}