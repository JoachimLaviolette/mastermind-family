using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /**
     * Create a new choose difficulty UI popup with the provided params
     */
    public static void CreateChooseDifficultyPopup()
    {
        Instantiate(AssetManager.instance.GetUIChooseDifficultyPopup(), Vector3.zero, Quaternion.identity);
    }

    /**
     * Create a new end game UI popup with the provided params
     */
    public static void CreateEndGamePopup(string title, string message)
    {
        GameObject go_UI_EndGame_Popup = Instantiate(AssetManager.instance.GetUIEndGamePopup(), Vector3.zero, Quaternion.identity);
        UIEndGamePopup UI_EndGame_Popup = go_UI_EndGame_Popup.GetComponent<UIEndGamePopup>();
        UI_EndGame_Popup.Setup(title, message);
    }
}
