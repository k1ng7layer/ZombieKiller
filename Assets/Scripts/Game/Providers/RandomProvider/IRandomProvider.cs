namespace Game.Providers.RandomProvider
{
    public interface IRandomProvider
    {
        float Value { get; }
        int Range(int min, int max);
        float Range(float min, float max);
    }
}