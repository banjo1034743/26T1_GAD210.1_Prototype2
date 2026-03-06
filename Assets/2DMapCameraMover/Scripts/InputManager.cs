using UnityEngine;
using UnityEngine.InputSystem;

namespace GAD210.Prototype2.MovementSystem
{
    public class InputManager : MonoBehaviour
    {
        #region Variables

        [Header("Input System")]

        [SerializeField] private InputActionAsset _inputActionAsset;

        private InputActionMap _inputActionMap;

        // === INPUT ACTIONS ===

        private InputAction _inputActionDrag;

        private InputAction _inputActionMousePos;

        #endregion

        #region Methods

        public Vector2 GetMousePosition()
        {
            //Debug.Log(_inputActionMousePos.ReadValue<Vector2>());

            return _inputActionMousePos.ReadValue<Vector2>();
        }

        public bool CheckIfStartedDragging()
        {
            return _inputActionDrag.WasPressedThisFrame();
        }

        public bool CheckIfPerformedDragging()
        {
            return _inputActionDrag.WasPerformedThisFrame();
        }

        public bool CheckIfStoppedDragging()
        {
            return _inputActionDrag.WasReleasedThisFrame();
        }

        private void InitializeInputActions()
        {
            _inputActionMap = _inputActionAsset.FindActionMap("Map");

            _inputActionDrag = _inputActionMap.FindAction("Drag");

            _inputActionMousePos = _inputActionMap.FindAction("Mouse Position");
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
