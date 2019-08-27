using UnityEngine;
using UnityEngine.SceneManagement;

public class UIChooseCustomSettingsPopupAction : MonoBehaviour
{
    public void Back()
    {
        UIManager.CreateChooseDifficultyPopup();
    }

    public void Launch()
    {
        // Check all params are valid
        // ...

        // Load all params
        // ...

        // Launch the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.SCENE_GAME_SCENE);
    }
}
