using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Abilities
{
    [Game]
    public class AbilityComponent : IComponent
    {
        public EAbilityType AbilityType;
    }
}