using Game.Utils;

namespace Game.Services.Ai.Abilities
{
    public interface IAiAbilityService
    {
        void CastAbility(GameEntity aiEntity, EAbilityType abilityType);
    }
}