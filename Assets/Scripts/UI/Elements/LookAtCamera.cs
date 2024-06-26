using UnityEngine;

namespace UI.Elements
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera _mainCamera;

        private void Start() => 
            _mainCamera = Camera.main;

        private void Update() => transform.rotation = Quaternion.LookRotation(transform.position - _mainCamera.transform.position);
    }
}