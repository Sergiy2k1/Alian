using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class AgentMove : MonoBehaviour
    {
        [SerializeField] private Transform centerPoint;
        [SerializeField] private float radius = 10.0f;
        [SerializeField] private float moveInterval = 3.0f;
        [SerializeField] private float maxTurnAngle = 90.0f; 
        private NavMeshAgent agent;
        private float timer;

        void Start()
        {
            Initial();
        }

        private void Update()
        {
            timer += Time.deltaTime;

            if (timer >= moveInterval)
            {
                Vector3 newDestination = GetRandomPointInFront(centerPoint.position, radius);
                agent.SetDestination(newDestination);
                timer = 0;
            }
        }

        private void Initial()
        {
            agent = GetComponent<NavMeshAgent>();
            timer = moveInterval;
        }

        private Vector3 GetRandomPointInFront(Vector3 center, float radius)
        {
            Vector3 forward = transform.forward;
            Vector3 randomDirection = Vector3.zero;

            for (int i = 0; i < 30; i++)
            {
                randomDirection = Random.insideUnitSphere * radius;
                randomDirection += center;

                Vector3 directionToRandomPoint = randomDirection - transform.position;
                float angle = Vector3.Angle(forward, directionToRandomPoint);

                if (angle <= maxTurnAngle)
                {
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
                    {
                        return hit.position;
                    }
                }
            }
            
            return transform.position;
        }

        private void OnDrawGizmos()
        {
            if (centerPoint != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(centerPoint.position, radius);
            }
        }
    }
}
