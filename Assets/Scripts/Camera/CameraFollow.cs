using UnityEngine;

namespace CameraLogic
{
    public class CameraFollow: MonoBehaviour
    {
        [SerializeField] private float _rotationAngleX;
        [SerializeField] private int _distance;
        [SerializeField] private float offsetY;

        [SerializeField] private Transform _following;

        private void LateUpdate()
        {
            if (_following == null) return;
            
            Quaternion rotation = Quaternion.Euler(_rotationAngleX, 0, 0);
            
            Vector3 position = rotation * new Vector3(0, 0, -_distance) + FollowingPointPosition();
            
            transform.rotation = rotation;
            transform.position = position;
        }
        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _following.position;
            followingPosition.y += offsetY;

            return followingPosition;
        }
    }
}