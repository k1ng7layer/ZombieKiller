using System.Collections.Generic;

namespace Db.PowerUps
{
    public interface IPowerUpBase
    {
        IReadOnlyList<PowerUpSettings> PowerUpS { get; }
        
        PowerUpSettings Get(int id);
    }
}