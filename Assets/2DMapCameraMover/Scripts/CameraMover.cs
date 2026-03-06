using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace GAD210.Prototype2.MovementSystem
{
    public class CameraMover : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private float _cameraMovementSpeed = 1f;

        //[SerializeField] private Vector3 _currentMousePosition = Vector3.zero; // Not using as local as would reset other wise each time MoveCamera is called

        [SerializeField] private Vector3 _dragOrigin = Vector3.zero;

        [SerializeField] private Vector3 _difference;

        [SerializeField] private bool _isDragging;

        [Header("Components")]

        [SerializeField] private Camera _camera;

        [Header("Scripts")]

        [SerializeField] private InputManager _inputManager;

        #endregion

        #region Methods

        // Use lerp to move camera toward mouse position
        private void BeginDraggingCamera()
        {
            if (_inputManager.CheckIfStartedDragging() == true)
            {
                _dragOrigin = CurrentMousePosition;
                _isDragging = _inputManager.CheckIfStartedDragging() || _inputManager.CheckIfPerformedDragging();
            }
            else if (_inputManager.CheckIfStoppedDragging() == true)
            {
                _isDragging = false;
            }

        }

        // EPIC LAMBDA!!!11!1
        private Vector3 CurrentMousePosition => _camera.ScreenToWorldPoint(_inputManager.GetMousePosition());

        private void DragCamera()
        {
            if (!_isDragging) return;

            _difference = CurrentMousePosition - transform.position;
            transform.position = _dragOrigin - _difference;
        }

        #endregion

        #region Unity Methods

        // Update is called once per frame
        void LateUpdate()
        {
            //_inputManager.GetMousePosition();
            //_inputManager.CheckIfDragging();

            BeginDraggingCamera();
            DragCamera();
        }

        #endregion
    }
}