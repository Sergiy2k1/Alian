using Service.Input;
using UnityEngine;

namespace MimicSpace
{ 
    public class Movement : MonoBehaviour
    {
        [Header("Controls")]
        [Tooltip("Body Height from ground")]
        [Range(0.5f, 5f)]
        public float height = 0.8f;
        public float speed = 5f;
        Vector3 velocity = Vector3.zero;
        public float velocityLerpCoef = 4f;
        Mimic myMimic;

        public LayerMask ignoreLayerMask;
        
        private IInputService _inputService;

        private void Awake()
        {
            _inputService = new MobileInputService();
        }

        private void Start()
        {
            ignoreLayerMask = ~LayerMask.GetMask("Player");
            myMimic = GetComponent<Mimic>();
        }

        void Update()
        {
            velocity = Vector3.Lerp(velocity, new Vector3(_inputService.GetHorizontal(), 0, _inputService.GetVertical()).normalized * speed, velocityLerpCoef * Time.deltaTime);

            // Assigning velocity to the mimic to assure great leg placement
            myMimic.velocity = velocity;

            transform.position = transform.position + velocity * Time.deltaTime;
            RaycastHit hit;
            Vector3 destHeight = transform.position;
            if (Physics.Raycast(transform.position + Vector3.up * 5f, -Vector3.up, out hit, ignoreLayerMask))
                destHeight = new Vector3(transform.position.x, hit.point.y + height, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, destHeight, velocityLerpCoef * Time.deltaTime);
        }
    }

}