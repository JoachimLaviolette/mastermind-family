using System;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Canvas UI_Canvas;
    private Text UI_Attempts;

    private const string UI_ATTEMPTS_STR = "ATTEMPTS LEFT: ";
    private const string UI_GAME_OVER_STR = "GAME OVER!";
    private const string UI_WIN_STR = "THAT'S A WIN!";

    private void Awake()
    {
        this.UI_Canvas = this.GetComponentInChildren<Canvas>();
        this.UI_Attempts = this.UI_Canvas.GetComponentInChildren<Text>();
    }

    private void Start()
    {
        this.RegisterEvents();
    }

    /**
     * Update the UI Attempts
     */
    private void UpdateUIAttempts(object sender, int attempts_left)
    {
        GameHandler game_handler = sender as GameHandler;

        switch (game_handler.GetGameState())
        {
            case GameHandler.GameState.GAME_OVER:
                this.UI_Attempts.text = UI_GAME_OVER_STR;
                UIManager.CreateUIPopup(UI_GAME_OVER_STR, "Sorry but... the game is over. You'll do better next time!");
                Debug.Log("Sorry but... the game is over. You'll do better next time!");

                return;
            case GameHandler.GameState.WIN:
                this.UI_Attempts.text = UI_WIN_STR;
                UIManager.CreateUIPopup(UI_WIN_STR, "Well done! You've found the right combination!");
                Debug.Log("Well done! You've found the right combination!");

                return;
        }

        this.UI_Attempts.text = UI_ATTEMPTS_STR + attempts_left;
    }

    /**
     * Subscribe to events
     */
    private void RegisterEvents()
    {
        GameHandler.e_OnAttemptsChange += this.UpdateUIAttempts;
    }
}
