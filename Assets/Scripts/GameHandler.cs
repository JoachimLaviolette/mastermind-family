using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [Range(1, 8)] public int m_nb_balls;
    private static int turn;

    private void Start()
    {
        this.Initialize();
    }

    private void Initialize()
    {
        turn = 0;
        this.IntializeOpponentRow();
        this.InitializePlayerRow();
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
}
