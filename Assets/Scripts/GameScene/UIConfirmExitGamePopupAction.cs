using UnityEngine;

public class UIConfirmExitGamePopupAction : MonoBehaviour
{
    /**
     * Handle discard action
     */
    public void Discard()
    {
        UIManager.DestroyConfirmExitGamePopup();
    }

    /**
     * Handle confirm action
     */
    public void Confirm()
    {
        SceneManager.Reset();
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.SCENE_GAME_MENU);
    }
}
