using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.InputSystem.XR;
using static UnityEditor.FilePathAttribute;

namespace Assets.Lesson_7.Source
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _pitchAnchor;
        [SerializeField] private Transform _yawAnchor;
        [SerializeField] private float _sensitivity;


        private float _pitch = 10f;
        private float _yaw = 0f;

        private Vector2 _lookInput;
        private Transform _transform;

        private void Start()
        {
            InputControl.OnLookInput += LookHandler;
            _transform = transform;
        }

        private void LateUpdate()
        {
            _pitch -= _lookInput.y * _sensitivity * Time.deltaTime;
            _yaw += _lookInput.x * _sensitivity * Time.deltaTime;

            if( _pitch < -25f)
            {
                _pitch = -25f;
            }
            else if( _pitch > 25f )
            {
                _pitch = 25f;
            }
            if (_pitch > -25f && _pitch < 25f)
                _pitchAnchor.localRotation = Quaternion.Euler(_pitch, 0f, 0f);

            _yawAnchor.rotation = Quaternion.Euler(0f, _yaw, 0f);
            _transform.rotation = _yawAnchor.rotation;
        }

        private void LookHandler(Vector2 lookInput)
        {
            _lookInput = lookInput;
        }

        public void SetYawAnchor(Transform yawAnchor)
        {
            _yawAnchor.rotation = yawAnchor.rotation = Quaternion.Euler(0f, _yaw, 0f);
            _yawAnchor = yawAnchor;
        }
    }
}