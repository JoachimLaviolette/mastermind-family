using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEndGamePopupAction : MonoBehaviour
{
    public void Continue()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.SCENE_GAME_MENU);
    }
}
