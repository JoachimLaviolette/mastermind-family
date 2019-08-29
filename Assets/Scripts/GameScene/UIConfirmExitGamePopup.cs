using UnityEngine;

public class UIConfirmExitGamePopup : MonoBehaviour
{
    private void Update()
    {
        // Back action
        if (Input.GetKeyDown(KeyCode.Escape)) UIManager.DestroyConfirmExitGamePopup();
    }
}