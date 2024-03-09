using System;
using Game.Utils;
using UnityEngine;

namespace Db.Abilities.Impl
{
    [CreateAssetMenu(menuName = "Settings/Abilities/" + nameof(AbilitiesBase), fileName = "AbilitiesBase")]
    public class AbilitiesBase : ScriptableObject, IAbilitiesBase
    {
        [SerializeField] private Ability[] abilities;
        
        public Ability Get(EAbilityType abilityType)
        {
            for (var i = 0; i < abilities.Length; i++)
            {
                var ability = abilities[i];
                if (ability.AbilityType == abilityType)
                    return ability;
            }

            throw new Exception($"[{typeof(AbilitiesBase)}]: Can't find ability with name: {abilityType}");
        }
    }
}