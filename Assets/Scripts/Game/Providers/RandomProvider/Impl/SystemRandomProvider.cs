using System;

namespace Game.Providers.RandomProvider.Impl
{
    public class SystemRandomProvider : IRandomProvider
    {
        private readonly Random _random = new Random();

        public float Value => (float) _random.NextDouble();
        public int Range(int min, int max) => _random.Next(min, max);

        public float Range(float min, float max)
            => (float) _random.NextDouble() * (max - min) + min;
    }
}