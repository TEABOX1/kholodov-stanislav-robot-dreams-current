using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.MainSource
{
    public class InputControl : MonoBehaviour
    {
        public static event Action<Vector2> OnMoveInput;
        public static event Action<Vector2> OnLookInput;
        public static event Action OnPrimaryInput;
        public static event Action<bool> OnSecondaryInput;
        public static event Action OnEscapeInput;
        public static event Action<bool> OnJumpInput;
        public static event Action<bool> OnRunInput;
        public static event Action<bool> OnCrouchInput;

        [SerializeField] private InputActionAsset m_inputActionAsset;
        [SerializeField] private string m_mapName;
        [SerializeField] private string m_UIMapName;
        [SerializeField] private string m_moveName;
        [SerializeField] private string m_lookAroundName;
        [SerializeField] private string m_primaryFireName;
        [SerializeField] private string m_secondaryFireName;
        [SerializeField] private string m_escapeName;
        [SerializeField] private string m_jumpName;
        [SerializeField] private string m_runName;
        [SerializeField] private string m_crouchName;

        private InputAction m_moveAction;
        private InputAction m_lookAroundAction;
        private InputAction m_primaryFireAction;
        private InputAction m_secondaryFireAction;
        private InputAction m_escapeAction;
        private InputAction m_jumpAction;
        private InputAction m_runAction;
        private InputAction m_crouchAction;

        private InputActionMap m_actionMap;
        private InputActionMap m_gameplayUIActionMap;

        private void OnEnable()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            m_inputActionAsset.Enable();

            m_actionMap = m_inputActionAsset.FindActionMap(m_mapName);
            m_gameplayUIActionMap = m_inputActionAsset.FindActionMap(m_UIMapName);

            m_moveAction = m_actionMap[m_moveName];
            m_lookAroundAction = m_actionMap[m_lookAroundName];
            m_primaryFireAction = m_actionMap[m_primaryFireName];
            m_secondaryFireAction = m_actionMap[m_secondaryFireName];
            m_jumpAction = m_actionMap[m_jumpName];
            m_runAction = m_actionMap[m_runName];
            m_crouchAction = m_actionMap[m_crouchName];
            m_escapeAction = m_gameplayUIActionMap[m_escapeName];

            m_moveAction.performed += MovePerformedHandler;
            m_moveAction.canceled += MoveCanceledHandler;

            m_lookAroundAction.performed += LookPerformedHandler;
            //m_lookAroundAction.canceled += LookCanceledHandler;

            m_primaryFireAction.performed += PrimaryFirePerformedHandler;

            m_secondaryFireAction.performed += SecondaryFirePerformedHandler;
            m_secondaryFireAction.canceled += SecondaryFireCanceledHandler;

            m_jumpAction.performed += JumpPerformedHandler;
            m_jumpAction.canceled += JumpCanceledHandler;

            m_runAction.performed += RunPerformedHandler;
            m_runAction.canceled += RunCanceledHandler;

            m_crouchAction.performed += CrouchPerformedHandler;
            m_crouchAction.canceled += CrouchCanceledHandler;

            m_escapeAction.performed += EscapePerformedHandler;

        }

        private void OnDisable()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            m_actionMap.Disable();
            m_inputActionAsset.Disable();
        }

        private void OnDestroy()
        {
            m_moveAction.performed -= MovePerformedHandler;
            m_moveAction.canceled -= MoveCanceledHandler;

            m_lookAroundAction.performed -= LookPerformedHandler;

            m_primaryFireAction.performed -= PrimaryFirePerformedHandler;

            m_secondaryFireAction.performed -= SecondaryFirePerformedHandler;
            m_secondaryFireAction.canceled -= SecondaryFireCanceledHandler;

            m_jumpAction.performed -= JumpPerformedHandler;
            m_jumpAction.canceled -= JumpCanceledHandler;

            m_runAction.performed -= RunPerformedHandler;
            m_runAction.canceled -= RunCanceledHandler;

            m_crouchAction.performed -= CrouchPerformedHandler;
            m_crouchAction.canceled -= CrouchCanceledHandler;

            m_escapeAction.performed -= EscapePerformedHandler;

            OnMoveInput = null;
            OnLookInput = null;
            OnPrimaryInput = null;
            OnSecondaryInput = null;
            OnEscapeInput = null;
            OnJumpInput = null;
            OnRunInput = null;
            OnCrouchInput = null;
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

        private void PrimaryFirePerformedHandler(InputAction.CallbackContext context)
        {
            OnPrimaryInput?.Invoke();
        }

        private void SecondaryFirePerformedHandler(InputAction.CallbackContext context)
        {
            OnSecondaryInput?.Invoke(true);
        }

        private void SecondaryFireCanceledHandler(InputAction.CallbackContext context)
        {
            OnSecondaryInput?.Invoke(false);
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

        private void EscapePerformedHandler(InputAction.CallbackContext context)
        {
            OnEscapeInput?.Invoke();
        }
    }
}