using System.Collections.Generic;
using Ecs.Extensions.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Combat
{
    [Game]
    public class AttackTargetsComponent : IComponent
    {
        public HashSet<Uid> Value;
    }
}