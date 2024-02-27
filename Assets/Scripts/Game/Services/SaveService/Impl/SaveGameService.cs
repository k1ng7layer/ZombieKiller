using System.Collections.Generic;
using System.Linq;
using Game.Data;
using Game.Services.Dao;
using Game.Services.Inventory;
using Zenject;

namespace Game.Services.SaveService.Impl
{
    public class SaveGameService : ISaveGameService, 
        IInitializable
    {
        private readonly IDao<GameData> _gameDataDao;
        private readonly GameContext _game;
        private readonly IPlayerInventoryService _playerInventoryService;

        public SaveGameService(
            IDao<GameData> gameDataDao, 
            GameContext game, 
            IPlayerInventoryService playerInventoryService
        )
        {
            _gameDataDao = gameDataDao;
            _game = game;
            _playerInventoryService = playerInventoryService;
        }
        
        public GameData CurrentGameData { get; private set; }

        public void Initialize()
        {
            var data = _gameDataDao.Load();

            CurrentGameData = data ?? new GameData
            {
                Player = new PlayerDto
                {
                    Buffs = new List<string>(),
                    Attributes = new List<AttributeDto>()
                },
                
                Inventory = new InventoryDto
                {
                    Items = new List<string>(),
                    EquippedItems = new List<string>(),
                }
            };
        }
        
        public void Save()
        {
            var player = _game.PlayerEntity;
            
            CurrentGameData.Inventory.Items = _playerInventoryService.GetAll().ToList();
            CurrentGameData.Player.Experience = player.Experience.Value;
            CurrentGameData.Player.Level = player.UnitLevel.Value;
            _gameDataDao.Save(CurrentGameData);
        }
    }
}