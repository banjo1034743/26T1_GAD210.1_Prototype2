using UnityEngine;

namespace GAD210.Prototype2.PhoneScroller
{
    public class PhoneScroller : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject textBoxCollection;

        [SerializeField] private float _scrollSpeed;

        [SerializeField] private RectTransform[] textBoxesRect;

        [SerializeField] private GameObject[] textBoxesObjects;

        [SerializeField] private float amountToMoveTextBoxDown;

        [SerializeField] private int _currentBoxToTranslateFrom;

        [SerializeField] private float yPosToMoveBoxesDown;

        [SerializeField] private InputManager _inputManager;

        #endregion

        #region Methods

        private void MoveScreen()
        {
            textBoxCollection.transform.Translate(Vector2.up * _inputManager.GetScrollValue() * _scrollSpeed);
        }

        private void ChangeTextBoxPosition()
        {
            foreach (var textBox in textBoxesRect)
            {
                if (textBox.position.y >= yPosToMoveBoxesDown)
                {
                    textBox.position = textBoxesRect[_currentBoxToTranslateFrom].transform.position;
                    textBox.Translate(Vector2.down * textBoxesRect[_currentBoxToTranslateFrom].sizeDelta.y * amountToMoveTextBoxDown);

                    switch (_currentBoxToTranslateFrom)
                    {
                        case 4:
                            _currentBoxToTranslateFrom = 0;
                            break;
                        case >= 0:
                            _currentBoxToTranslateFrom++;
                            break;
                    }
                }
            }
        }

        #endregion

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _currentBoxToTranslateFrom = textBoxesObjects.Length - 1;
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(_inputManager.GetScrollValue());
            MoveScreen();
            ChangeTextBoxPosition();
        }

        #endregion
    }
}