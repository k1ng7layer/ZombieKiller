using Db.Inventory;
using Db.Player;
using Ecs.Commands;
using Ecs.Extensions.UidGenerator;
using Ecs.Utils.LinkedEntityRepository;
using Game.Data;
using Game.Providers.GameFieldProvider;
using Game.Services.Dao;
using Game.Services.Inventory;
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

            SetupAttributes(player, saveData);
            
            
            player.AddUnitLevel(saveData == null ? 1 : saveData.Player.Level);
            player.AddExperience(saveData == null ? 0f : saveData.Player.Experience);

            var starterWeapon = _playerSettings.StarterWeapon;
            
            if (starterWeapon != string.Empty)
            {
                CreateWeapon(starterWeapon, playerUid);
            }
            
            _linkedEntityRepository.Add(playerView.transform.GetHashCode(), player);
        }

        private void CreateWeapon(string weaponId, Uid playerUid)
        {
            _commandBuffer.EquipWeapon(weaponId, playerUid, true);
        }
        
        private void SetupAttributes(GameEntity player, GameData gameData)
        {
            var hasHealth = TryLoadAttribute(EUnitStat.HEALTH, gameData, out var maxHealth);
            player.AddHealth(hasHealth ? maxHealth : _playerSettings.BaseMaxHealth);
            player.AddMaxHealth(hasHealth ? maxHealth : _playerSettings.BaseMaxHealth);
            player.AddBaseMaxHealth(hasHealth ? maxHealth : _playerSettings.BaseMaxHealth);
            
            var hasMagicDmg = TryLoadAttribute(EUnitStat.ABILITY_POWER, gameData, out var abPower);
            player.AddMagicDamage(hasMagicDmg ? 0 : abPower);
            player.AddAttackCooldown(0);
            player.AddAttackSpeed(_playerSettings.BaseAttackSpeed);
            player.IsUnit = true;
        }
        
        private bool TryLoadAttribute(
            EUnitStat unitStat, 
            GameData gameData, 
            out float value
        )
        {
            value = 0;
            
            if (gameData == null)
                return false;
            
            foreach (var attributeDto in gameData.Player.Attributes)
            { 
                var attrType = (EUnitStat)attributeDto.Attribute;
                
                if (unitStat != attrType)
                    continue;

                value = attributeDto.Value;

                return true;
            }
            
            return false;
        }
    }
}