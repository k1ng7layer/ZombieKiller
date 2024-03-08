using Game.Utils;
using UniRx.Triggers;
using UnityEngine;

namespace AnimationTriggers
{
    public class TakeDamageTrigger : ObservableStateMachineTrigger
    {
        [SerializeField] private float normilizedTime;
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.normalizedTime >= normilizedTime)
            {
                animator.SetBool(AnimationKeys.TakeDamage, false);
                
                return;
            }
            
            base.OnStateUpdate(animator, stateInfo, layerIndex);
        }
    }
}