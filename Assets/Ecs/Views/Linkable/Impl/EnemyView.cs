using AiTasks;
using BehaviorDesigner.Runtime;
using Db.BTrees;
using Db.Enemies;
using Game.Utils;
using Game.Views;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.Utils;
using UnityEngine;
using Zenject;

namespace Ecs.Views.Linkable.Impl
{
    public class EnemyView : UnitView
    {
        [SerializeField] private UnitParamBarView healthBarView;
        [SerializeField] private BehaviorTree behaviorTree;
        
        [Inject] private IEnemyParamsBase _enemyParamsBase;
        [Inject] private DiContainer _diContainer;
        [Inject] private IBTreesBase _bTreesBase;

        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            var enemyEntity = (GameEntity)entity;

            enemyEntity.SubscribeHealth(OnHealthChanged).AddTo(unsubscribe);
            enemyEntity.SubscribeEnemy(OnEnemy).AddTo(unsubscribe);
        }

        private void OnHealthChanged(GameEntity entity, float value)
        {
            var enemyParams = _enemyParamsBase.GetEnemyParams(entity.Enemy.EnemyType);
            var percents = value / enemyParams.BaseHealth;
            Debug.Log($"EnemyView OnHealthChanged percents: {percents}, value: {value}");
            healthBarView.SetValue(percents);
            
            _animator.SetTrigger(AnimationKeys.TakeDamage);
        }
        
        private void OnEnemy(GameEntity entity, EEnemyType enemyType)
        {
            InitializeBTree(enemyType);
        }

        protected override void OnDead(GameEntity _)
        {
            base.OnDead(_);
            
            healthBarView.gameObject.SetActive(false);
        }

        private void InitializeBTree(EEnemyType enemyType)
        {
            var bTree = _bTreesBase.GetBehaviorTree(enemyType);
            
            behaviorTree.QueueAllTasksForInject(_diContainer);
            
            behaviorTree.ExternalBehavior = bTree;
            
            behaviorTree.EnableBehavior();
        }
    }
}