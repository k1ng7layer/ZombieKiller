using BehaviorDesigner.Runtime;
using Game.Utils;

namespace Db.BTrees
{
    public interface IBTreesBase
    {
        ExternalBehaviorTree GetBehaviorTree(EEnemyType enemyType);
    }
}