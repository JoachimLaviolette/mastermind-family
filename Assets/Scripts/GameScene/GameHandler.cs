using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    // Game params
    private int m_nb_balls;
    private int m_attempts;

    private GameState m_state;
    private int turn;
    private Dictionary<int, BallManager.Color> colors;
    private int color_index;
    private int ball_index;
    private Ball current_ball;
    private PlayerRow current_player_row;
    private OpponentRow opponent_row;
    List<Ball> player_balls, opponent_balls;
    public static EventHandler<int> e_OnAttemptsChange;

    private const int DEFAULT_COLOR_INDEX = -1;

    public enum GameState
    {
        PLAYING,
        GAME_OVER,
        WIN,
    };

    private void Start()
    {
        this.Initialize();
    }

    private void Update()
    {
        this.HandlePlayerInputs();
    }

    /**
     * Initialize the game 
     */
    private void Initialize()
    {
        this.InitializeGameParams();
        this.turn = 0;
        this.colors = BallManager.GetColors();
        this.IntializeOpponentRow();
        this.InitializePlayerRow();
        this.InitializeCurrentBall();
        this.opponent_balls = this.opponent_row.GetBalls();
        this.InitializeGameState();
    }

    /**
     * Initialize game params from the SceneParams class
     */
     private void InitializeGameParams()
    {
        this.m_attempts = SceneManager.GetNbAttempts();
        Debug.Log(this.m_attempts);
        this.m_nb_balls = SceneManager.GetNbBalls();
    }

    /**
     * Initialize the opponent row
     */
    private void IntializeOpponentRow()
    {
        // First create the opponent row parent
        GameObject go_OpponentRow = AssetManager.instance.GetOpponentRow();
        Vector3 position = Utils.GetOpponentRowPositionOnBoard();
        Transform ts_OpponentRow = Instantiate(go_OpponentRow.transform, position, Quaternion.identity);
        this.opponent_row = ts_OpponentRow.GetComponent<OpponentRow>();

        // Then setup the row
        this.opponent_row.Initialize(this.m_nb_balls, this.turn);
    }

    /**
     * Inialize the player row
     */
    private void InitializePlayerRow()
    {
        // First create the player row parent
        GameObject go_PlayerRow = AssetManager.instance.GetPlayerRow();
        Vector3 position = Utils.GetPlayerRowPositionOnBoard();
        Transform ts_playerRow = Instantiate(go_PlayerRow.transform, position, Quaternion.identity);
        PlayerRow playerRow = ts_playerRow.GetComponent<PlayerRow>();

        // Then setup the row
        playerRow.Initialize(this.m_nb_balls, this.turn);

        // Set current row
        this.current_player_row = playerRow;
    }

    /**
     * Initialize the current ball
     */
    private void InitializeCurrentBall()
    {
        // Set the color and ball indices
        this.color_index = 0;
        this.ball_index = 0;

        this.SetCurrentBall();
    }

    /**
     * Initialize the state of the game
     */
    private void InitializeGameState()
    {
        // Set the state of the game
        this.m_state = GameState.PLAYING;

        // Notify the UI to update
        e_OnAttemptsChange?.Invoke(this, this.m_attempts - this.turn);
    }

    /**
     * Set the current ball according to the current index
     */
    private void SetCurrentBall()
    {
        if (this.current_ball) this.current_ball.SetIsCurrent(false);
        
        this.current_ball = this.current_player_row.GetBall(this.ball_index);
        this.current_ball.SetIsCurrent(true);
    }

    /**
     * Handle all player inputs
     */
    private void HandlePlayerInputs()
    {
        // If the current ball is colored retrieve the color index
        if (this.current_ball.IsColored()) this.color_index = this.current_ball.GetColorIndex();
        else this.color_index = DEFAULT_COLOR_INDEX;

        // We change the current ball color
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {   
            if (this.color_index == DEFAULT_COLOR_INDEX) this.color_index = 8;
            else if (this.color_index == 0) this.color_index = 8;
            else this.color_index--;

            this.current_ball.SetColor(this.colors[this.color_index]);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (this.color_index == DEFAULT_COLOR_INDEX) this.color_index = 0;
            else if (this.color_index == 8) this.color_index = 0;
            else this.color_index++;

            this.current_ball.SetColor(this.colors[this.color_index]);
        }

        // We change the current ball
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (this.ball_index == 0) this.ball_index = this.m_nb_balls - 1;
            else this.ball_index--;

            this.color_index = DEFAULT_COLOR_INDEX;
            this.SetCurrentBall();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (this.ball_index == this.m_nb_balls - 1) this.ball_index = 0;
            else this.ball_index++;

            this.color_index = DEFAULT_COLOR_INDEX;
            this.SetCurrentBall();
        }

        // Check the current row
        if (Input.GetKeyDown(KeyCode.Return)) this.CheckCurrentRow();

        // Quit the game
        if (Input.GetKeyDown(KeyCode.Escape)) this.Quit();
    }

    private void CheckCurrentRow()
    {
        // If at least one of the balls is not colored yet 
        if (!this.current_player_row.IsFull())
        {
            // Notify user
            // ...
            Debug.Log("The current player row is not fully colored. Complete it!");

            // Continue the current turn
            return;
        }

        // Otherwise, check the current combination
        this.CheckCombination();
    }

    /**
     * Check the current user combination
     */
    private void CheckCombination()
    {
        this.player_balls = this.current_player_row.GetBalls();
        bool is_good_pos, is_color_exist = false, initialize_new_row = false;

        for (int x = 0, y = this.player_balls.Count - 1; x < this.player_balls.Count; x++, y--)
        {
            Ball player_ball = this.player_balls[x];

            // Check if the facing balls have the same color
            is_good_pos = player_ball.Equals(this.opponent_balls[y]);

            // Check if the color of the ball exists somewhere else in the row
            is_color_exist = !this.opponent_row.IsColorFullyFound(player_ball.GetColor(), current_player_row);

            // If at least one of the balls is not well placed
            // We have to initialize a new row next turn
            if (!is_good_pos) initialize_new_row = true;

            // We update the checker
            this.UpdateChecker(x, is_good_pos, is_color_exist);
        }

        if (initialize_new_row)
        {
            Debug.Log("The combination was not successfull. Try again!");
            this.turn++;

            if (this.turn >= this.m_attempts)
            {
                this.GameOver();

                return;
            }

            this.InitializeNewRow();

            return;
        }

        // If here, means the combination was successful
        // So... it's a win!
        this.Win();
    }

    /**
     * Update the checker to notify the user what was ok in his combination
     */
    private void UpdateChecker(int player_ball_pos, bool is_good_pos, bool is_color_exist)
    {
        this.current_player_row.UpdateChecker(player_ball_pos, is_good_pos, is_color_exist);
    }

    /**
     * Initialize a new player row
     */
    private void InitializeNewRow()
    {
        e_OnAttemptsChange?.Invoke(this, this.m_attempts - this.turn);
        this.current_player_row.SetIsActive(false);
        this.InitializePlayerRow();
        this.InitializeCurrentBall();
    }

    /**
     * End the game (win)
     */
    private void Win()
    {
        // Set the state of the game
        this.m_state = GameState.WIN;

        // Notify the UI to update
        e_OnAttemptsChange?.Invoke(this, this.m_attempts - this.turn);
    }

    /**
     * End the game (game over)
     */
    private void GameOver()
    {
        // Set the state of the game
        this.m_state = GameState.GAME_OVER;
        
        // Notify the UI to update
        e_OnAttemptsChange?.Invoke(this, this.m_attempts - this.turn);
    }

    /**
     * Return the current state of the game
     */
    public GameState GetGameState()
    {
        return this.m_state;
    }

    /**
     * Display the popup to confirm quit action
     */
    private void Quit()
    {
        UIManager.CreateConfirmExitGamePopup();
    }
}
