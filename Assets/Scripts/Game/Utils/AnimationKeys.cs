using UnityEngine;

namespace Game.Utils
{
    public static class AnimationKeys
    {
        public static readonly int Walk = Animator.StringToHash("Walk");
        public static readonly int Attack = Animator.StringToHash("Attack");
        public static readonly int RangedAttack = Animator.StringToHash("RangedAttack");
        public static readonly int Death = Animator.StringToHash("Death");
        public static readonly int Movement = Animator.StringToHash("Movement");
        public static readonly int AutoMovement = Animator.StringToHash("AutoMovement");
        public static readonly int TakeDamage = Animator.StringToHash("TakeDamage");
        public static readonly int AttackSpeedMultiplier = Animator.StringToHash("AttackSpeedMultiplier");
        public static readonly int SitDown = Animator.StringToHash("SitDown");
        public static readonly int AutoMove = Animator.StringToHash("AutoMove");
    }
}