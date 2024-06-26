using UnityEngine;

namespace Hero
{
    public class Tongue: MonoBehaviour
    {
        public LineRenderer lineRenderer;
        public Transform tongueOrigin;
        public float tongueSpeed = 10f;
        public float tongueRetractSpeed = 15f;

        private Transform target;
        private bool isShooting = false;
        private bool isRetracting = false;

        void Start()
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, tongueOrigin.position);
        }

        void Update()
        {
            if (isShooting)
            {
                ShootTongue();
            }
            else if (isRetracting)
            {
                RetractTongue();
            }
            else
            {
                lineRenderer.SetPosition(1, tongueOrigin.position);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (!isShooting && !isRetracting)
            {
                target = other.transform;
                isShooting = true;
            }
        }

        void ShootTongue()
        {
            if (target != null)
            {
                lineRenderer.SetPosition(1, Vector3.MoveTowards(lineRenderer.GetPosition(1), target.position, tongueSpeed * Time.deltaTime));
                if (Vector3.Distance(lineRenderer.GetPosition(1), target.position) < 0.1f)
                {
                    isShooting = false;
                    isRetracting = true;
                }
            }
        }

        void RetractTongue()
        {
            lineRenderer.SetPosition(1, Vector3.MoveTowards(lineRenderer.GetPosition(1), tongueOrigin.position, tongueRetractSpeed * Time.deltaTime));
            if (Vector3.Distance(lineRenderer.GetPosition(1), tongueOrigin.position) < 0.1f)
            {
                if (target != null)
                {
                    target.position = tongueOrigin.position;
                    target = null;
                }
                isRetracting = false;
            }
        }
    }
}