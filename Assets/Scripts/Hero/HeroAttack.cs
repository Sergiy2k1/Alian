using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace Hero
{
    public class HeroAttack : MonoBehaviour, IAttackable
    {
        [SerializeField] private float damage = 10f;
        [SerializeField] private int maxAttackableEnemies = 3;
        [SerializeField] private float attackInterval = 1.0f; 
        [SerializeField] private CapsuleCollider attackCollider; 
     
        private float attackTimer;
        
        private List<IHealth> _enemiesInRange = new List<IHealth>();
        
        public void Attack(IHealth health) => health.TakeDamage(damage);

        private void Update()
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackInterval)
            {
                for (int i = 0; i < _enemiesInRange.Count && i < maxAttackableEnemies; i++)
                {
                    Attack(_enemiesInRange[i]);
                }
                attackTimer = 0f;
            }
            
            _enemiesInRange.RemoveAll(enemy => enemy.Current <= 0);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            IHealth enemyHealth = other.GetComponent<IHealth>();
            if (enemyHealth != null && !_enemiesInRange.Contains(enemyHealth))
            {
                _enemiesInRange.Add(enemyHealth);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            IHealth enemyHealth = other.GetComponent<IHealth>();
            if (enemyHealth != null && _enemiesInRange.Contains(enemyHealth))
            {
                _enemiesInRange.Remove(enemyHealth);
            }
        }

        
    }
}