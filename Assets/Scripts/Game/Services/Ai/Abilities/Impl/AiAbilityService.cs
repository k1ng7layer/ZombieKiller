using System.Collections.Generic;
using Game.Utils;

namespace Game.Services.Ai.Abilities.Impl
{
    public class AiAbilityService : IAiAbilityService
    {
        private readonly Dictionary<EAbilityType, IAbilityCastParams> _abilityCastParamsList = new();

        public AiAbilityService(List<IAbilityCastParams> abilityCastParamsList)
        {
            foreach (var ability in abilityCastParamsList)
            {
                _abilityCastParamsList.Add(ability.AbilityType, ability);
            }
        }
        
        public void CastAbility(GameEntity aiEntity, EAbilityType abilityType)
        {
            _abilityCastParamsList[abilityType].UseAbility(aiEntity);
        }
    }
}