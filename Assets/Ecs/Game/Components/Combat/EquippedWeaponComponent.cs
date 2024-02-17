using Ecs.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Combat
{
    [Game]
    [Event(EventTarget.Self)]
    public class EquippedWeaponComponent : IComponent
    {
        public EquippedWeaponInfo Value;
    }
}