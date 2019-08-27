using UnityEngine;

public class Actions : MonoBehaviour
{
    public void Play()
    {
        UIManager.CreateChooseDifficultyPopup();
    }

    public void Credits()
    {
        // Load credits
    }

    public void Exit()
    {
        Application.Quit();
    }
}
