using Db.PowerUps;

namespace Game.Providers.PowerUpProvider
{
    public interface IPowerUpProvider
    {
        PowerUpSettings Get();
    }
}