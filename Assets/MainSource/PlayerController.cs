using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.InputSystem.XR;

namespace Assets.MainSource
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Vector2 _regularHeightOffset;
        [SerializeField] private Vector2 _crouchedHeightOffset;

        private Transform _transform;

        private float _defaultCharacterHeight;
        private Vector3 _defaultCharacterScale;

        private Vector2 _moveInput;
        private bool _isPlayerJump;

        private Vector3 _playerVelocity;
        private bool _groundPlayer;
        private float jumpHeight = 5.0f;
        private float gravityValue = -9.81f;

        private void Start()
        {
            InputControl.OnMoveInput += MoveHandler;
            InputControl.OnRunInput += RunHandler;
            InputControl.OnCrouchInput += CrouchHandler;
            InputControl.OnJumpInput += JumpHandler;
            _transform = transform;
            _defaultCharacterHeight = _characterController.height;
            _defaultCharacterScale = transform.localScale;
        }

        private void FixedUpdate()
        {
            Vector3 forward = _transform.forward;
            Vector3 right = _transform.right;
            Vector3 movement = forward * _moveInput.y + right * _moveInput.x;
            _characterController.SimpleMove(movement * _speed);

            _groundPlayer = _characterController.isGrounded;
            if (_groundPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }

            if (_isPlayerJump && _groundPlayer)
            {
                _playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            }
            _playerVelocity.y += gravityValue * Time.deltaTime;
            _characterController.Move(_playerVelocity * Time.deltaTime);
        }

        private void MoveHandler(Vector2 moveInput)
        {
            _moveInput = moveInput;//.normalized;
        }

        private void JumpHandler(bool isJump)
        {
            _isPlayerJump = isJump;
        }

        private void RunHandler(bool runInput)
        {
            if(runInput)
                _speed = 30;
            else
                _speed = 15;
        }

        private void CrouchHandler(bool crouchInput)
        {
            Vector3 size = _transform.localScale;
            if (crouchInput)
            {
                _characterController.height = _crouchedHeightOffset.x;
                _characterController.center = new Vector3( 0f, _crouchedHeightOffset.y, 0f );
                size.y = _defaultCharacterScale.y / 2;
                _speed = 5;
            }
            else
            {
                _characterController.height = _regularHeightOffset.x;
                _characterController.center = new Vector3(0f, _regularHeightOffset.y, 0f);
                size.y = _defaultCharacterScale.y;
                _speed = 15;
            }
            _playerTransform.localScale = size;
        }
    }
}