using Logic;
using UnityEngine;
using System;

namespace Enemy
{
    public class EnemyHealth: MonoBehaviour, IHealth
    {
        public event Action HealthChanged;
        
        public EnemyAnimator Animator;

        [SerializeField] private float _current;
        [SerializeField] private float _max;

        public float Current
        {
            get => _current;
            set => _current = value;
        }
        public float Max
        {
            get => _max;
            set => _max = value;
        }
        

        
        public void TakeDamage(float damage)
        {
            Current -= damage;

            Animator.PlayTakeDamage();

            HealthChanged?.Invoke();
        }
    }
}