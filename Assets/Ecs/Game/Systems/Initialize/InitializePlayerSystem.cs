using Db.Player;
using Ecs.Commands;
using Ecs.Extensions.UidGenerator;
using Ecs.Utils.LinkedEntityRepository;
using Game.Providers.GameFieldProvider;
using Game.Utils;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Initialize
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 50, nameof(EFeatures.Initialization))]
    public class InitializePlayerSystem : IInitializeSystem
    {
        private readonly IGameFieldProvider _gameFieldProvider;
        private readonly IPlayerSettings _playerSettings;
        private readonly ICommandBuffer _commandBuffer;
        private readonly ILinkedEntityRepository _linkedEntityRepository;
        private readonly GameContext _game;

        public InitializePlayerSystem(
            IGameFieldProvider gameFieldProvider,
            IPlayerSettings playerSettings,
            ICommandBuffer commandBuffer,
            ILinkedEntityRepository linkedEntityRepository,
            GameContext game
        )
        {
            _gameFieldProvider = gameFieldProvider;
            _playerSettings = playerSettings;
            _commandBuffer = commandBuffer;
            _linkedEntityRepository = linkedEntityRepository;
            _game = game;
        }
        
        public void Initialize()
        {
            var playerView = _gameFieldProvider.GameField.PlayerView;
            var player = _game.CreateEntity();
            
            playerView.Link(player);
            
            var playerUid = UidGenerator.Next();
            
            player.IsPlayer = true;
            player.IsCanMove = true;
            player.AddUid(playerUid);
            player.AddRotation(playerView.transform.rotation);
            player.AddPosition(playerView.transform.position);
            player.AddHealth(100);

            var starterWeapon = _playerSettings.StarterWeapon;
            
            if (starterWeapon != EWeaponId.None)
            {
                CreateWeapon(starterWeapon, playerUid);
            }
            
            _linkedEntityRepository.Add(playerView.transform.GetHashCode(), player);
        }

        private void CreateWeapon(EWeaponId weaponId, Uid playerUid)
        {
            _commandBuffer.EquipWeapon(weaponId, playerUid);
        }
    }
}