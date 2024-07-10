using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public static class AnimHash
    {
        public static readonly int IdleHash = Animator.StringToHash("Idle");
        public static readonly int RunHash = Animator.StringToHash("Run");
        public static readonly int AttackHash = Animator.StringToHash("Attack");
        public static readonly int ChargeHash = Animator.StringToHash("Charge");
        public static readonly int DeadHash = Animator.StringToHash("Dead");
    }
}
