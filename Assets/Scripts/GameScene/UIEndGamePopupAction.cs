using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEndGamePopupAction : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene(AssetManager.SCENE_GAME_MENU);
    }
}
