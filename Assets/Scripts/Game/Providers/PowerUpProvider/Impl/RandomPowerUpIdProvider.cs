using Db.PowerUps;
using Game.Providers.RandomProvider;

namespace Game.Providers.PowerUpProvider.Impl
{
    public class RandomPowerUpIdProvider : IPowerUpIdProvider
    {
        private readonly IPowerUpBase _powerUpBase;
        private readonly IRandomProvider _randomProvider;

        public RandomPowerUpIdProvider(
            IPowerUpBase powerUpBase, 
            IRandomProvider randomProvider
        )
        {
            _powerUpBase = powerUpBase;
            _randomProvider = randomProvider;
        }
        
        public int Get()
        {
            var powerUps = _powerUpBase.PowerUpS;
            var randomId = _randomProvider.Range(0, powerUps.Count);

            return randomId;
        }
    }
}