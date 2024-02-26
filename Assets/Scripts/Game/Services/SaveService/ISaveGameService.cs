using Game.Data;

namespace Game.Services.SaveService
{
    public interface ISaveGameService
    {
        GameData CurrentGameData { get; }
        void Save();
    }
}