using Db.Enemies;
using Game.Utils;
using Game.Views;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.Utils;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Ecs.Views.Linkable.Impl
{
    public class EnemyView : UnitView
    {
        [SerializeField] private UnitParamBarView healthBarView;
        [SerializeField] private NavMeshAgent navMeshAgent;
        
        [Inject] private IEnemyParamsBase _enemyParamsBase;
        private GameEntity _enemyEntity;

        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            _enemyEntity = (GameEntity)entity;

            _enemyEntity.AddNavmeshAgent(navMeshAgent);
            _enemyEntity.SubscribeHealth(OnHealthChanged).AddTo(unsubscribe);
            _enemyEntity.SubscribeDestination(OnDestinationAdded).AddTo(unsubscribe);
            _enemyEntity.SubscribeMoving(_ => { OnMovingStateChanged(true);}).AddTo(unsubscribe);
            _enemyEntity.SubscribeMovingRemoved(_=> {OnMovingStateChanged(false);}).AddTo(unsubscribe);
            
            navMeshAgent.updatePosition = false;
            navMeshAgent.updateRotation = false;
            navMeshAgent.stoppingDistance = _enemyEntity.AttackRange.Value;
            navMeshAgent.speed = _enemyEntity.MoveSpeed.Value / Constants.RbSpeedToNavmeshScale;
        }

        private void OnHealthChanged(GameEntity entity, float value)
        {
            var enemyParams = _enemyParamsBase.GetEnemyParams(entity.Enemy.EnemyType);
            var percents = value / enemyParams.BaseHealth;
            Debug.Log($"EnemyView OnHealthChanged percents: {percents}, value: {value}");
            healthBarView.SetValue(percents);
            
            // _animator.SetTrigger(AnimationKeys.TakeDamage);
            // _animator.ResetTrigger(AnimationKeys.TakeDamage);
        }

        protected override void OnDead(GameEntity _)
        {
            base.OnDead(_);
            
            healthBarView.gameObject.SetActive(false);
        }

        private void OnDestinationAdded(GameEntity _, Vector3 destination)
        {
            navMeshAgent.SetDestination(destination);
        }

        private void OnMovingStateChanged(bool isMove)
        {
            //navMeshAgent.enabled = isMove;
            //_animator.SetFloat(AnimationKeys.Movement, isMove ? 0.7 : 0, Time.deltaTime);
        }

        protected override void OnDirectionChanged(GameEntity entity, Vector3 dir)
        {
            base.OnDirectionChanged(entity, dir);
            
            // var horizontalVelocity = new Vector3(dir.x, 0, dir.z);
            // var isMoving = horizontalVelocity.magnitude >= 0.01f;
            //
            // if (isMoving)
            // {
            //     transform.rotation = Quaternion.LookRotation(horizontalVelocity, Vector3.up);
            // }
        }

        private void Update()
        {
            if (_enemyEntity == null)
                return;

            var transform1 = transform;
            _enemyEntity.Position.Value = transform1.position;
            _enemyEntity.Rotation.Value = transform1.rotation;
        }
    }
}