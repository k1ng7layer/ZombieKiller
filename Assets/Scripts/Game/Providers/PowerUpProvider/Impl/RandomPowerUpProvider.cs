using Db.PowerUps;
using Game.Providers.RandomProvider;

namespace Game.Providers.PowerUpProvider.Impl
{
    public class RandomPowerUpProvider : IPowerUpProvider
    {
        private readonly IPowerUpBase _powerUpBase;
        private readonly IRandomProvider _randomProvider;

        public RandomPowerUpProvider(
            IPowerUpBase powerUpBase, 
            IRandomProvider randomProvider
        )
        {
            _powerUpBase = powerUpBase;
            _randomProvider = randomProvider;
        }
        
        public PowerUpSettings Get()
        {
            var powerUps = _powerUpBase.PowerUpS;
            var randomId = _randomProvider.Range(0, powerUps.Count);
            var randomPowerUpSettings = powerUps[randomId];

            return randomPowerUpSettings;
        }
    }
}