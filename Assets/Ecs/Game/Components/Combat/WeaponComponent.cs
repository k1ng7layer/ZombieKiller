using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Combat
{
    [Game]
    public class WeaponComponent : IComponent
    {
        public EWeaponId WeaponId;
    }
}