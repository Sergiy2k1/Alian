using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

namespace Enemy
{
    public class EnemyDeath: MonoBehaviour
    {
        [SerializeField] private EnemyHealth health; 
        [SerializeField] private EnemyAnimator animator;

        [SerializeField] private GameObject DeathFx;
        
        public event Action Happened;

        private void Start() => 
            health.HealthChanged += HealthChanged;
        
        private void OnDestroy() => 
            health.HealthChanged -= HealthChanged;

        private void HealthChanged()
        {
            if (health.Current <= 0)
                Die();
        }

        private void Die()
        {
            health.HealthChanged -= HealthChanged;

            animator.PlayDeath();

            SpawnDeathFx();
            StartCoroutine(DestroyTimer());

            Happened?.Invoke();
        }

        private void SpawnDeathFx() => 
            Instantiate(DeathFx, transform.position, Quaternion.identity);
        
        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
        }
    }
}