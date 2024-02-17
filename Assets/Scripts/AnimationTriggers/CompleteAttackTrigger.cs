using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace AnimationTriggers
{
    public class CompleteAttackTrigger : ObservableStateMachineTrigger
    {
        [SerializeField] private float _endNormilizedTime;
        private readonly ReactiveCommand _attackEnd = new();
        
        public IObservable<Unit> AttackEnd => _attackEnd;
        
        // public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        // {
        //     _attackEnd?.Execute();
        // }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            
            if (stateInfo.normalizedTime >= _endNormilizedTime)
                _attackEnd?.Execute();
        }
    }
}