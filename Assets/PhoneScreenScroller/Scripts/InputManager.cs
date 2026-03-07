using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace GAD210.Prototype2.PhoneScroller
{
    public class InputManager : MonoBehaviour
    {
        #region Variables

        [Header("Input System")]

        [SerializeField] private InputActionAsset _inputActionAsset;

        private InputActionMap _inputActionMap;

        // === INPUT ACTIONS ===

        private InputAction _inputActionScroll;

        //private InputControl _inputControlScroll;

        #endregion

        #region Methods

        public float GetScrollValue()
        {
            return _inputActionScroll.ReadValue<float>();
        }

        private void InitializeInputActions()
        {
            _inputActionMap = _inputActionAsset.FindActionMap("Phone");

            _inputActionScroll = _inputActionMap.FindAction("Scroll");
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitializeInputActions();
        }

        private void OnEnable()
        {
            _inputActionAsset.Enable();
        }

        private void OnDisable()
        {
            _inputActionAsset.Disable();
        }

        #endregion
    }
}