using UnityEngine;

namespace Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Dead = Animator.StringToHash("Dead");

        private Animator _animator;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void PlayTakeDamage() => _animator.SetTrigger(TakeDamage);

        public void PlayDeath() => _animator.SetTrigger(Dead);

        public void PlayIdle() => _animator.SetTrigger(Idle);

        
    }
}