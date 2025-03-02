using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.InputSystem.XR;
using static UnityEditor.FilePathAttribute;

namespace Assets.MainSource
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _pitchAnchor;
        [SerializeField] private Transform _yawAnchor;
        [SerializeField] private float _sensitivity;


        private float _pitch = 0f;
        private float _yaw = 0f;

        private Vector2 _lookInput;

        private void Start()
        {
            InputControl.OnLookInput += LookHandler;
        }

        private void LateUpdate()
        {
            //_pitch -= _lookInput.y * _sensitivity * Time.deltaTime;
            //_yaw += _lookInput.x * _sensitivity * Time.deltaTime;

            _pitchAnchor.localRotation = Quaternion.Euler(0f, _pitch, 0f);

            if (_yaw < -20f)
            {
                _yaw = -20f;
            }
            else if (_yaw > 25f)
            {
                _yaw = 25f;
            }
            if (_yaw > -25f && _yaw < 25f)
                _yawAnchor.rotation = Quaternion.Euler(0f, 0f, _yaw);

            Debug.Log("_yaw" +  _yaw);
            Debug.Log("Euler" + Quaternion.Euler(_yaw, 0f, 0f));
        }

        private void LookHandler(Vector2 lookInput)
        {
            lookInput *= _sensitivity;
            _pitch += lookInput.x;
            _yaw += -lookInput.y;
        }
    }
}