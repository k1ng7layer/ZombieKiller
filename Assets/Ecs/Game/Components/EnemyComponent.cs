using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    [Event(EventTarget.Self)]
    public class EnemyComponent : IComponent
    {
        public EEnemyType EnemyType;
    }
}