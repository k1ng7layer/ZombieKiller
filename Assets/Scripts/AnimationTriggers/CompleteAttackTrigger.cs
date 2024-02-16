using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace AnimationTriggers
{
    public class CompleteAttackTrigger : ObservableStateMachineTrigger
    {
        private readonly ReactiveCommand _attackEnd = new();
        
        public IObservable<Unit> AttackEnd => _attackEnd;
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _attackEnd?.Execute();
        }
    }
}