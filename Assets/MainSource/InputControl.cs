using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Lesson_7.Source
{
    public class InputControl : MonoBehaviour
    {
        public static event Action<Vector2> OnMoveInput;
        public static event Action<Vector2> OnLookInput;
        public static event Action<bool> OnJumpInput;
        public static event Action<bool> OnRunInput;
        public static event Action<bool> OnCrouchInput;

        [SerializeField] private InputActionAsset m_inputActionAsset;
        [SerializeField] private string m_mapName;
        [SerializeField] private string m_moveName;
        [SerializeField] private string m_lookAroundName;
        [SerializeField] private string m_jumpName;
        [SerializeField] private string m_runName;
        [SerializeField] private string m_crouchName;

        private InputAction m_moveAction;
        private InputAction m_lookAroundAction;
        private InputAction m_jumpAction;
        private InputAction m_runAction;
        private InputAction m_crouchAction;

        private void OnEnable()
        {
            m_inputActionAsset.Enable();
            InputActionMap actionMap = m_inputActionAsset.FindActionMap(m_mapName);
            m_moveAction = actionMap[m_moveName];
            m_lookAroundAction = actionMap[m_lookAroundName];
            m_jumpAction = actionMap[m_jumpName];
            m_runAction = actionMap[m_runName];
            m_crouchAction = actionMap[m_crouchName];

            m_moveAction.performed += MovePerformedHandler;
            m_moveAction.canceled += MoveCanceledHandler;

            m_lookAroundAction.performed += LookPerformedHandler;
            m_lookAroundAction.canceled += LookCanceledHandler;

            m_jumpAction.performed += JumpPerformedHandler;
            m_jumpAction.canceled += JumpCanceledHandler;

            m_runAction.performed += RunPerformedHandler;
            m_runAction.canceled += RunCanceledHandler;

            m_crouchAction.performed += CrouchPerformedHandler;
            m_crouchAction.canceled += CrouchCanceledHandler;

        }

        private void OnDisable()
        {
            m_inputActionAsset.Disable();
        }

        private void OnDestroy()
        {
            OnMoveInput = null;
            OnLookInput = null;
        }

        private void MovePerformedHandler(InputAction.CallbackContext context)
        {
            OnMoveInput?.Invoke(context.ReadValue<Vector2>());
        }

        private void MoveCanceledHandler(InputAction.CallbackContext context)
        {
            OnMoveInput?.Invoke(context.ReadValue<Vector2>());
        }

        private void LookPerformedHandler(InputAction.CallbackContext context)
        {
            OnLookInput?.Invoke(context.ReadValue<Vector2>());
        }

        private void LookCanceledHandler(InputAction.CallbackContext context)
        {
            OnLookInput?.Invoke(context.ReadValue<Vector2>());
        }

        private void JumpPerformedHandler(InputAction.CallbackContext context)
        {
            OnJumpInput?.Invoke(true);
        }

        private void JumpCanceledHandler(InputAction.CallbackContext context)
        {
            OnJumpInput?.Invoke(false);
        }

        private void RunPerformedHandler(InputAction.CallbackContext context)
        {
            OnRunInput?.Invoke(true);
        }

        private void RunCanceledHandler(InputAction.CallbackContext context)
        {
            OnRunInput?.Invoke(false);
        }

        private void CrouchPerformedHandler(InputAction.CallbackContext context)
        {
            OnCrouchInput?.Invoke(true);
        }

        private void CrouchCanceledHandler(InputAction.CallbackContext context)
        {
            OnCrouchInput?.Invoke(false);
        }
    }
}