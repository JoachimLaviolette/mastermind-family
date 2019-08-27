using UnityEngine;

public class UIChooseCustomSettingsPopup : MonoBehaviour
{
    private void Update()
    {
        // Back action
        if (Input.GetKeyDown(KeyCode.Escape)) UIManager.CreateChooseDifficultyPopup();
    }
}