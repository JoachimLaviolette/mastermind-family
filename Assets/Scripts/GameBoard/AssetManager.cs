using UnityEngine;

public class AssetManager : MonoBehaviour
{
    public static AssetManager instance;
    [SerializeField] private GameObject pf_GameBoard;
    [SerializeField] private Ball pf_Ball;
    [SerializeField] private Checker pf_Checker;
    [SerializeField] private CheckerItem pf_CheckerItem;
    [SerializeField] private PlayerRow pf_PlayerRow;
    [SerializeField] private OpponentRow pf_OpponentRow;
    [SerializeField] private GameObject pf_UI_Popup;
    [SerializeField] private Camera player_camera;

    public const string SCENE_GAME_BOARD = "GameBoard";
    public const string SCENE_GAME_MAIN_MENU = "GameMainMenu";

    private void Awake()
    {
        instance = this;
    }

    public GameObject GetGameBoard()
    {
        return this.pf_GameBoard;
    }

    public GameObject GetBall()
    {
        return this.pf_Ball.gameObject;
    }

    public GameObject GetChecker()
    {
        return this.pf_Checker.gameObject;
    }

    public GameObject GetCheckerItem()
    {
        return this.pf_CheckerItem.gameObject;
    }

    public GameObject GetPlayerRow()
    {
        return this.pf_PlayerRow.gameObject;
    }

    public GameObject GetOpponentRow()
    {
        return this.pf_OpponentRow.gameObject;
    }

    public GameObject GetUIPopup()
    {
        return this.pf_UI_Popup;
    }

    public Camera GetPlayerCamera()
    {
        return this.player_camera;
    }
}
