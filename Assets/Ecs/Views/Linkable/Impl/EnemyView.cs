using System;
using Ai.SharedVariables;
using BehaviorDesigner.Runtime;
using Db.BTrees;
using Db.Enemies;
using Game.Utils;
using Game.Views;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.Utils;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Ecs.Views.Linkable.Impl
{
    public class EnemyView : UnitView
    {
        [SerializeField] private UnitParamBarView healthBarView;
        [SerializeField] private BehaviorTree behaviorTree;
        [SerializeField] private NavMeshAgent enemyAgent;
        
        [Inject] private IEnemyParamsBase _enemyParamsBase;
        [Inject] private DiContainer _diContainer;
        [Inject] private IBTreesBase _bTreesBase;

        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);
            
            SelfEntity.SubscribeHealth(OnHealthChanged).AddTo(unsubscribe);
            SelfEntity.SubscribeEnemy(OnEnemy).AddTo(unsubscribe);
            SelfEntity.SubscribeDestinationPosition(OnDestinationPosition).AddTo(unsubscribe);
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
            
            enemyAgent.enabled = false;
        }

        private void OnDestinationPosition(GameEntity entity, Vector3 value)
        {
            enemyAgent.SetDestination(value);
        }
        
        private void InitializeBTree(EEnemyType enemyType)
        {
            var bTree = _bTreesBase.GetBehaviorTree(enemyType);
            
            behaviorTree.QueueAllTasksForInject(_diContainer);
            
            behaviorTree.ExternalBehavior = bTree;
            behaviorTree.SetVariable("Uid", new SharedUid
            {
                Value = SelfEntity.Uid.Value
            });
            
            behaviorTree.EnableBehavior();
        }
    }
}