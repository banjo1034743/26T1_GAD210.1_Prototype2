using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace GAD210.Prototype2.MovementSystem
{
    public class CameraMover : MonoBehaviour
    {
        #region Variables

        [Header("Data")]

        [SerializeField] private float _cameraMovementSpeed = 1f;

        [SerializeField] private Vector3 _currentMousePosition = Vector3.zero; // Not using as local as would reset other wise each time MoveCamera is called

        [SerializeField] private Vector3 _dragOrigin = Vector3.zero;

        [Header("Components")]

        [SerializeField] private Camera _camera;

        [Header("Scripts")]

        [SerializeField] private InputManager _inputManager;

        #endregion

        #region Methods

        // Use lerp to move camera toward mouse position
        private void MoveCamera()
        {
            //if (Input.GetMouseButtonDown(0))
            //{
            //    _dragOrigin = Input.mousePosition;
            //    return;
            //}

            //if (!Input.GetMouseButton(0)) return;

            //Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - _dragOrigin);
            //Vector3 move = new Vector3(pos.x * _cameraMovementSpeed, pos.y * _cameraMovementSpeed, transform.position.z);

            //transform.Translate(move, Space.World);

            //----

            //if (_inputManager.CheckIfDragging() == true)
            //{
            //    _dragOrigin = _camera.ScreenToViewportPoint(_inputManager.GetMousePosition());
            //    return;
            //}

            ////transform.position = new Vector3(-_currentMousePosition.x, -_currentMousePosition.y, transform.position.z);

            //Vector2 newPosition = _camera.ScreenToViewportPoint(_inputManager.GetMousePosition() - _dragOrigin);
            //Vector3 amountToMovement = new Vector3(newPosition.x * _cameraMovementSpeed, transform.position.z, newPosition.y * _cameraMovementSpeed);

            //transform.Translate(amountToMovement, Space.World);

            _currentMousePosition = _inputManager.GetMousePosition();

            if (_inputManager.CheckIfDragging() == true)
            {
                Vector3 newPos = Vector3.Lerp(transform.position, _camera.ScreenToWorldPoint(_inputManager.GetMousePosition()), _cameraMovementSpeed);
                transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
            }

        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            //_inputManager.GetMousePosition();
            //_inputManager.CheckIfDragging();

            MoveCamera();
        }

        #endregion
    }
}