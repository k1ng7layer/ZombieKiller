using Db.Inventory;
using Db.Player;
using Ecs.Commands;
using Ecs.Extensions.UidGenerator;
using Ecs.Utils.LinkedEntityRepository;
using Game.Data;
using Game.Providers.GameFieldProvider;
using Game.Services.Dao;
using Game.Services.Inventory;
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
        private readonly IPlayerInventorySettings _playerInventorySettings;
        private readonly IPlayerInventoryService _playerInventoryService;
        private readonly IDao<GameData> _saveGameData;
        private readonly GameContext _game;

        public InitializePlayerSystem(
            IGameFieldProvider gameFieldProvider,
            IPlayerSettings playerSettings,
            ICommandBuffer commandBuffer,
            ILinkedEntityRepository linkedEntityRepository,
            IPlayerInventorySettings playerInventorySettings,
            IPlayerInventoryService playerInventoryService,
            IDao<GameData> saveGameData,
            GameContext game
        )
        {
            _gameFieldProvider = gameFieldProvider;
            _playerSettings = playerSettings;
            _commandBuffer = commandBuffer;
            _linkedEntityRepository = linkedEntityRepository;
            _playerInventorySettings = playerInventorySettings;
            _playerInventoryService = playerInventoryService;
            _saveGameData = saveGameData;
            _game = game;
        }
        
        public void Initialize()
        {
            var saveData = _saveGameData.Load();
            
            var playerView = _gameFieldProvider.GameField.PlayerView;
            var player = _game.CreateEntity();
            
            playerView.Link(player);
            
            var playerUid = UidGenerator.Next();
            
            player.IsPlayer = true;
            player.IsCanMove = true;
            player.AddUid(playerUid);
            player.AddRotation(playerView.transform.rotation);
            player.AddPosition(playerView.transform.position);
            player.AddHealth(_playerSettings.BaseMaxHealth);
            player.AddMaxHealth(_playerSettings.BaseMaxHealth);
            player.AddBaseMaxHealth(_playerSettings.BaseMaxHealth);
            player.AddMagicDamage(0);
            player.AddAdditionalHealth(0);
            player.AddAttackCooldown(0);
            player.AddAttackSpeed(_playerSettings.BaseAttackSpeed);
            player.IsUnit = true;
            
            //TODO: save this
            player.AddUnitLevel(saveData == null ? 1 : saveData.Player.Level);
            //player.AddExperience(100f);
            player.AddExperience(saveData == null ? 0f : saveData.Player.Experience);

            var starterWeapon = _playerSettings.StarterWeapon;
            
            if (starterWeapon != string.Empty)
            {
                CreateWeapon(starterWeapon, playerUid);
            }
            
            _linkedEntityRepository.Add(playerView.transform.GetHashCode(), player);

            InitializeInventory();
        }

        private void CreateWeapon(string weaponId, Uid playerUid)
        {
            _commandBuffer.EquipWeapon(weaponId, playerUid);
        }

        private void InitializeInventory()
        {
            var capacity = _playerInventorySettings.BasicCapacity;
            
            _playerInventoryService.ChangeCapacity(capacity);

            foreach (var starterItemId in _playerInventorySettings.StarterItemsIds)
            {
                _playerInventoryService.TryAdd(starterItemId);
            }
        }
    }
}