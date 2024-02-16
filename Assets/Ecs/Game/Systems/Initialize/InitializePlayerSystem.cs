using Ecs.Extensions.UidGenerator;
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
            var playerView = _gameFieldProvider.GameField.UnitView;
            var player = _game.CreateEntity();
            var playerUid = UidGenerator.Next();
            
            player.IsPlayer = true;
            player.IsCanMove = true;
            player.AddUid(playerUid);
            player.AddRotation(playerView.transform.rotation);
            
            var weaponUid = CreateWeapon(playerUid);
            
            player.ReplaceEquippedWeapon(weaponUid);
            
            playerView.Link(player);
        }

        private Uid CreateWeapon(Uid playerUid)
        {
            var weaponEntity = _game.CreateEntity();
            var weaponUid = UidGenerator.Next();
            
            weaponEntity.AddUid(weaponUid);
            weaponEntity.AddWeapon("BasicSword");
            weaponEntity.AddOwner(playerUid);

            return weaponUid;
        }
    }
}