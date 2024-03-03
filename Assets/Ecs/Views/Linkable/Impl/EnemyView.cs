using System.Collections;
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
            _enemyEntity.SubscribeActiveRemoved(_ =>
            {
                // navMeshAgent.isStopped = true;
                // navMeshAgent.enabled = false;
                
            }).AddTo(unsubscribe);

            _enemyEntity.SubscribeHitCounter((_, _) =>
            {
                navMeshAgent.isStopped = true;
                navMeshAgent.enabled = false;
                Observable.NextFrame().Subscribe(_ =>
                {
                    _rb.AddForce(-transform.forward * 100f, ForceMode.Impulse);
                }).AddTo(unsubscribe);
                

                Observable.FromCoroutine(StopForce).Subscribe(_ =>
                {
                    navMeshAgent.isStopped = false;
                    navMeshAgent.enabled = true;
                    navMeshAgent.Warp(_rb.transform.position);
                    _enemyEntity.Position.Value = transform.position;
                    _enemyEntity.IsActive = true;
                });
            }).AddTo(unsubscribe);
            
            navMeshAgent.updatePosition = false;
            navMeshAgent.updateRotation = false;
            navMeshAgent.stoppingDistance = _enemyEntity.AttackRange.Value;
            navMeshAgent.speed = _enemyEntity.MoveSpeed.Value / Constants.RbSpeedToNavmeshScale;
        }

        private void OnHealthChanged(GameEntity entity, float value)
        {
            var enemyParams = _enemyParamsBase.GetEnemyParams(entity.Enemy.EnemyType);
            var percents = value / enemyParams.BaseHealth;
            //Debug.Log($"EnemyView OnHealthChanged percents: {percents}, value: {value}");
            healthBarView.SetValue(percents);
            
            // _animator.SetTrigger(AnimationKeys.TakeDamage);
            // _animator.ResetTrigger(AnimationKeys.TakeDamage);
        }

        protected override void OnDead(GameEntity _)
        {
            base.OnDead(_);
            
            healthBarView.gameObject.SetActive(false);
            navMeshAgent.isStopped = true;
            OnDirectionChanged(_, Vector3.zero);
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
            // Debug.Log($"OnDirectionChanged: velocity {_rb.velocity}, navmesh : {navMeshAgent.isStopped}");
            // if (Input.GetKeyDown(KeyCode.P))
            // { 
            //     // navMeshAgent.isStopped = true;
            //     // navMeshAgent.enabled = false;
            //     //
            //     _rb.AddForce(-transform.forward * 5f, ForceMode.Impulse);
            //     
            //     
            //     // navMeshAgent.isStopped = false;
            //     // navMeshAgent.enabled = true;
            //     //navMeshAgent.velocity = _rb.velocity;
            //
            //
            //     //navMeshAgent.isStopped = false;
            //
            //     // _enemyEntity.MoveDirection.Value = -transform.forward * 40f;
            //     // _rb.velocity = -transform.forward * 40f;
            // }
        }

        private IEnumerator StopForce()
        {
            float time = 0.5f;

            while (time > 0)
            {
                yield return null;

                time -= Time.deltaTime;
            }
        }
        
    }
}