using System;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [Range(1, 8)] public int m_nb_balls;
    private int turn;
    private Dictionary<int, BallManager.Color> colors;
    private int color_index;
    private int ball_index;
    private Ball current_ball;
    private PlayerRow current_row;

    private const int DEFAULT_COLOR_INDEX = -1;

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
        this.turn = 0;
        this.colors = BallManager.GetColors();
        this.color_index = 0;
        this.ball_index = 0;
        this.IntializeOpponentRow();
        this.InitializePlayerRow();
        this.SetCurrentBall();
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
        OpponentRow opponentRow = ts_OpponentRow.GetComponent<OpponentRow>();

        // Then setup the row
        opponentRow.Initialize(this.m_nb_balls, this.turn);
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
        this.current_row = playerRow;
    }

    /**
     * Set the current ball according to the current index
     */
    private void SetCurrentBall()
    {
        if (this.current_ball) this.current_ball.SetIsCurrent(false);
        this.current_ball = this.current_row.GetBall(this.ball_index);
        this.current_ball.SetIsCurrent(true);
    }

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
    }
}
