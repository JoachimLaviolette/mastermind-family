using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static GameObject UI_popup_choose_difficulty;
    private static GameObject UI_popup_choose_custom_settings;
    private static GameObject UI_popup_confirm_exit_game;

    /**
     * Create a new popup to choose game difficulty
     */
    public static void CreateChooseDifficultyPopup()
    {
        // Destroy choose difficulty popup
        if (UI_popup_choose_custom_settings != null) Destroy(UI_popup_choose_custom_settings);

        // Instantiate the new popup
        UI_popup_choose_difficulty = Instantiate(AssetManager.instance.GetUIChooseDifficultyPopup(), Vector3.zero, Quaternion.identity);
    }

    /**
     * Create a new popup to choose custom game settings
     */
    public static void CreateChooseCustomSettingsPopup()
    {
        // Destroy choose difficulty popup
        if (UI_popup_choose_difficulty != null) Destroy(UI_popup_choose_difficulty);

        // Instantiate the new popup
        UI_popup_choose_custom_settings = Instantiate(AssetManager.instance.GetUIChooseCustomSettingsPopup(), Vector3.zero, Quaternion.identity);
    }

    /**
     * Create a new popup to display end game message
     */
    public static void CreateEndGamePopup(string title, string message)
    {
        GameObject go_UI_EndGame_Popup = Instantiate(AssetManager.instance.GetUIEndGamePopup(), Vector3.zero, Quaternion.identity);
        UIEndGamePopup UI_EndGame_Popup = go_UI_EndGame_Popup.GetComponent<UIEndGamePopup>();
        UI_EndGame_Popup.Setup(title, message);
    }

    /**
     * Create a new popup to ask the player to confirm
     * Game exit
     */
    public static void CreateConfirmExitGamePopup()
    {
        if (UI_popup_confirm_exit_game != null) return;

        // Instantiate the new popup
        UI_popup_confirm_exit_game = Instantiate(AssetManager.instance.GetUIConfirmExitGamePopup(), Vector3.zero, Quaternion.identity);
    }

    /**
     * Destroy exit game popup
     */
    public static void DestroyConfirmExitGamePopup()
    {
        Destroy(UI_popup_confirm_exit_game);
    }
}
