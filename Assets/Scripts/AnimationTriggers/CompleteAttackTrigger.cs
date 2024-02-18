using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace AnimationTriggers
{
    public class CompleteAttackTrigger : ObservableStateMachineTrigger
    {
        [SerializeField] private float _endNormilizedTime;
        [SerializeField] private float _startNormilizedTime;
        private readonly ReactiveCommand _attackEnd = new();
        private readonly ReactiveCommand _attackStart = new();
        private bool _completed;
        private bool _started;
        
        public IObservable<Unit> AttackEnd => _attackEnd;
        public IObservable<Unit> AttackStart => _attackStart;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _completed = false;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);

            if (stateInfo.normalizedTime >= _startNormilizedTime && !_started)
            {
                _attackStart?.Execute();
                _started = true;
            }

            if (stateInfo.normalizedTime >= _endNormilizedTime && !_completed)
            {
                _attackEnd?.Execute();
                _completed = true;
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            
            _started = false;
        }
    }
}