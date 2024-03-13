using Game.Utils;

namespace Db.Abilities
{
    public interface IAbilitiesBase
    {
        Ability Get(EAbilityType abilityType);
    }
}