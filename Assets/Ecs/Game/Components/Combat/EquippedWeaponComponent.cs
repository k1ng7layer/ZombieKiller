using Ecs.Extensions.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Combat
{
    [Game]
    public class EquippedWeaponComponent : IComponent
    {
        public Uid Value;
    }
}