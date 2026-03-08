using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickResponder : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    #region Unity Methods

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("I have been clicked");
        SceneManager.LoadScene(1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("I have been clicked");
        SceneManager.LoadScene(1);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("I have been clicked");
        SceneManager.LoadScene(1);
    }

    #endregion
}
