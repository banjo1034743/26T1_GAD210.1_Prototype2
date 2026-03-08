using UnityEngine;
using UnityEngine.EventSystems;

namespace GAD210.Prototype2.MovementSystem
{
    public class FriendPopUpActivator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        #region Variables

        [SerializeField] private GameObject _popUp;

        #endregion

        #region Unity Methods

        public void OnPointerEnter(PointerEventData eventData)
        {
            _popUp.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _popUp.SetActive(false);
        }

        private void Start()
        {
            _popUp.SetActive(false);
        }

        #endregion
    }
}