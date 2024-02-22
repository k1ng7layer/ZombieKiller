using System;
using BehaviorDesigner.Runtime;
using Game.Utils;

namespace Db.BTrees
{
    [Serializable]
    public class BehaviourTreeVo
    {
        public EEnemyType enemyType;
        public ExternalBehaviorTree behaviorTree;
    }
}