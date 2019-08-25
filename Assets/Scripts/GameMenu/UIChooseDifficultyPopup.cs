using UnityEngine;
using UnityEngine.SceneManagement;

public class UIChooseDifficultyPopup : MonoBehaviour
{
    public void Easy()
    {
        // Load params in static class
        SceneParams.SetGameDifficulty(SceneParams.GAME_DIFFICULTY.EASY);

        // Load the scene
        SceneManager.LoadScene(AssetManager.SCENE_GAME_SCENE);
    }

    public void Normal()
    {
        // Load params in static class
        SceneParams.SetGameDifficulty(SceneParams.GAME_DIFFICULTY.NORMAL);

        // Load the scene
        SceneManager.LoadScene(AssetManager.SCENE_GAME_SCENE);
    }

    public void Hard()
    {
        // Load params in static class
        SceneParams.SetGameDifficulty(SceneParams.GAME_DIFFICULTY.HARD);

        // Load the scene
        SceneManager.LoadScene(AssetManager.SCENE_GAME_SCENE);
    }
}
