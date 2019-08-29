using UnityEngine;
using UnityEngine.SceneManagement;

public class UIChooseDifficultyPopupAction : MonoBehaviour
{
    public void Easy()
    {
        // Load params in static class
        SceneManager.SetGameDifficulty(SceneManager.GAME_DIFFICULTY.EASY);

        // Load the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.SCENE_GAME_SCENE);
    }

    public void Normal()
    {
        // Load params in static class
        SceneManager.SetGameDifficulty(SceneManager.GAME_DIFFICULTY.NORMAL);

        // Load the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.SCENE_GAME_SCENE);
    }

    public void Hard()
    {
        // Load params in static class
        SceneManager.SetGameDifficulty(SceneManager.GAME_DIFFICULTY.HARD);

        // Load the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.SCENE_GAME_SCENE);
    }

    public void Custom()
    {
        // Open custom settings popup
        UIManager.CreateChooseCustomSettingsPopup();
    }
}
