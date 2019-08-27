using UnityEngine;

public class UIChooseDifficultyPopup : MonoBehaviour
{
    private void Update()
    {
        // Back action
        if (Input.GetKeyDown(KeyCode.Escape)) UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.SCENE_GAME_MENU);
    }
}