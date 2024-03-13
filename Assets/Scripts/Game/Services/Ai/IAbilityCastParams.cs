using Game.Utils;

namespace Game.Services.Ai
{
    public interface IAbilityCastParams
    {
        EAbilityType AbilityType { get; }
        void UseAbility(GameEntity entity);
    }
}