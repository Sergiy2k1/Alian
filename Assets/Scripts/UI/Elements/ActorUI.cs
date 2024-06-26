
using Logic;
using UnityEngine;

namespace UI.Elements
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private  HpBar HpBar;

        private IHealth _health;
        
        public void Construct(IHealth health)
        {
            _health = health;

            _health.HealthChanged += UpdateHpBar;
        }
        
        private void Start()
        {
            IHealth health = GetComponent<IHealth>();

            if (health != null)
                Construct(health);
        }
        
        private void UpdateHpBar() => 
            HpBar.SetValue(_health.Current, _health.Max);


        private void OnDestroy() => 
            _health.HealthChanged -= UpdateHpBar;
    }
}