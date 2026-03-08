using UnityEngine;
using System.Collections.Generic;

namespace GAD210.Prototype2.PhoneScroller
{
    public class PhoneScroller : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject textBoxCollection;

        [SerializeField] private float _scrollSpeed;

        [SerializeField] private RectTransform[] textBoxesRect;

        [SerializeField] private GameObject[] textBoxesObjects;

        [SerializeField] private float amountToMoveTextBox;

        [SerializeField] private int _currentBoxToTranslateFrom;

        [Tooltip("The Y value that a text box must exceed when the screen is scrolled down before moving to the bottom of the text boxes")]
        [SerializeField] private float yPosToMoveBoxesUp; // 2000

        [Tooltip("The Y value that a text box must exceed when the screen is scrolled up before moving to the top of the text boxes")]
        [SerializeField] private float yPosToMoveBoxesDown; // -2000?

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
                // check if we're scrolling up before checking this
                if (_inputManager.GetScrollValue() > 0)
                {
                    if (textBox.position.y >= yPosToMoveBoxesUp)
                    {
                        RectTransform rectTransformToUse = GetTextBoxWithLowestYPos();
                        textBox.position = rectTransformToUse.position;

                        textBox.Translate(Vector2.down * (textBox.sizeDelta.y + 120));
                    }
                }
                // check if we're scrolling up before checking this
                else if (_inputManager.GetScrollValue() < 0)
                {
                    // If the current text box we're checking is below a certain y pos, run the steps below
                    if (textBox.position.y <= yPosToMoveBoxesDown)
                    {
                        // Set the position of the current text box to the highest text box in terms of Y pos, using the method to check which one this is
                        RectTransform rectTransformToUse = GetTextBoxWithHighestYPos();
                        textBox.position = rectTransformToUse.position;

                        // Translate from that text box's positon upward, multiplying how much we do so by the size of that text box and amountToMoveTextBox
                        textBox.Translate(Vector2.up * (textBox.sizeDelta.y + 120));
                    }
                }
            }
        }

        // Method which goes through textBoxRect array to find the text box at the highest Y pos
        private RectTransform GetTextBoxWithHighestYPos()
        {
            float highestYPos = 0;
            RectTransform rectTransformToReturn = null;

            foreach (var textBox in textBoxesRect)
            {
                if (textBox.position.y > highestYPos)
                {
                    highestYPos = textBox.position.y;
                    rectTransformToReturn = textBox;
                }
            }

            return rectTransformToReturn;
        }

        private RectTransform GetTextBoxWithLowestYPos()
        {
            float lowestYPos = 2000; // set high so we can ensure that this will be reset to at least one of the text box's Y pos
            RectTransform rectTransformToReturn = null;

            foreach (var textBox in textBoxesRect)
            {
                if (textBox.position.y < lowestYPos)
                {
                    lowestYPos = textBox.position.y;
                    rectTransformToReturn = textBox;
                }
            }

            return rectTransformToReturn;
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