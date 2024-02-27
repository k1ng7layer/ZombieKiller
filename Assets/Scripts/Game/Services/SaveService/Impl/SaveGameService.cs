using System.Collections.Generic;
using Game.Data;
using Game.Services.Dao;
using Zenject;

namespace Game.Services.SaveService.Impl
{
    public class SaveGameService : ISaveGameService, 
        IInitializable
    {
        private readonly IDao<GameData> _gameDataDao;

        public SaveGameService(IDao<GameData> gameDataDao)
        {
            _gameDataDao = gameDataDao;
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
            _gameDataDao.Save(CurrentGameData);
        }
    }
}