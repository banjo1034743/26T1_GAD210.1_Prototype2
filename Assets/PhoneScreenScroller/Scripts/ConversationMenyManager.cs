using UnityEngine;
using UnityEngine.SceneManagement;

public class ConversationMenyManager : MonoBehaviour
{
    public void ExitConversationMenu()
    {
        SceneManager.LoadScene(0);
    }
}
