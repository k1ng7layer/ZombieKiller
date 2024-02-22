using System;
using BehaviorDesigner.Runtime;
using Game.Utils;
using UnityEngine;

namespace Db.BTrees.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(BTreesBase), fileName = nameof(BTreesBase))]
    public class BTreesBase : ScriptableObject, IBTreesBase
    {
        [SerializeField] private BehaviourTreeVo[] behaviorTrees;
        
        
        public ExternalBehaviorTree GetBehaviorTree(EEnemyType enemyType)
        {
            foreach (var behaviorTree in behaviorTrees)
            {
                if (behaviorTree.enemyType != enemyType) continue;

                return behaviorTree.behaviorTree;
            }
            
            throw new Exception($"[{nameof(BTreesBase)}]: Can't find behavior tree for enemy type: {enemyType}");
        }
    }
}