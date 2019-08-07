using System;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [Range(1, 8)] public int m_nb_balls;
    private static int turn;

    private void Start()
    {
        this.Initialize();
        this.RegisterEvents();
    }

    private void Initialize()
    {
        turn = 0;
        this.IntializeOpponentRow();
        this.InitializePlayerRow();
    }

    private void RegisterEvents()
    {
        Ball.e_OnClickColoredBall += this.ChangeBallColor;
        Ball.e_OnClickBlankBall += this.ChooseBallColor;
    }

    private void IntializeOpponentRow()
    {
        // First create the opponent row parent
        GameObject pf_OpponentRow = AssetManager.instance.GetOpponentRow();
        Vector3 position = Utils.GetOpponentRowPositionOnBoard();
        Transform ts_OpponentRow = Instantiate(pf_OpponentRow.transform, position, Quaternion.identity);
        OpponentRow opponentRow = ts_OpponentRow.GetComponent<OpponentRow>();

        // Then setup the row
        opponentRow.Initialize(this.m_nb_balls, turn);
    }

    private void InitializePlayerRow()
    {
        // First create the player row parent
        GameObject pf_PlayerRow = AssetManager.instance.GetPlayerRow();
        Vector3 position = Utils.GetPlayerRowPositionOnBoard();
        Transform ts_playerRow = Instantiate(pf_PlayerRow.transform, position, Quaternion.identity);
        PlayerRow playerRow = ts_playerRow.GetComponent<PlayerRow>();

        // Then setup the row
        playerRow.Initialize(this.m_nb_balls, turn);
    }

    private void ChangeBallColor(object sender, EventArgs e)
    {
        // Open UI popup to change the color of the ball
        Debug.Log("Change ball color event!");

        Ball ball = sender as Ball;
        int random_index = UnityEngine.Random.Range(0, 8);
        BallManager.Color color = BallManager.GetColor(random_index);
        ball.SetColor(color);
    }

    private void ChooseBallColor(object sender, EventArgs e)
    {
        // Open UI popup to choose the color for the ball
        Debug.Log("Choose ball color event!");

        Ball ball = sender as Ball;
        int random_index = UnityEngine.Random.Range(0, 8);
        BallManager.Color color = BallManager.GetColor(random_index);
        ball.SetColor(color);
    }
}
