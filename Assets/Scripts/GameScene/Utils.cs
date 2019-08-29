using UnityEngine;

public class Utils : MonoBehaviour
{
    private static Camera player_camera = AssetManager.instance.GetPlayerCamera();
    private static Vector3 POSITION_0_OPPONENT_ROW = AssetManager.instance.GetOpponentRow().transform.position;
    private static Vector3 POSITION_0_PLAYER_ROW = AssetManager.instance.GetPlayerRow().transform.position;
    private static Vector3 POSITION_0_CHECKER = AssetManager.instance.GetChecker().transform.position;
    private static Vector3 POSITION_0_CHECKER_ITEM = AssetManager.instance.GetCheckerItem().transform.position;

    public static Vector3 GetOpponentRowPositionOnBoard()
    {
        return POSITION_0_OPPONENT_ROW;
    }

    public static Vector3 GetPlayerRowPositionOnBoard()
    {
        return POSITION_0_PLAYER_ROW;
    }

    public static void SetupPlayerRowPositionOnBoard(PlayerRow playerRow, int row_index)
    {
        Vector3 position = playerRow.transform.position;

        // Have to deal with the row index
        // Only in the context of a player row
        position.z += row_index * 0.5f;

        playerRow.transform.position = position;
    }

    public static Vector3 GetBallPosition(int index, bool is_opponent)
    {
        Vector3 position = is_opponent ? POSITION_0_OPPONENT_ROW : POSITION_0_PLAYER_ROW;
        // offset of 0.3f between each ball of the same row
        position.x += index * 0.3f; 

        return position;
    }

    public static Vector3 GetCheckerPosition()
    {
        return POSITION_0_CHECKER + POSITION_0_PLAYER_ROW;
    }

    public static Vector3 GetCheckItemPosition(int index)
    {
        Vector3 position = POSITION_0_CHECKER_ITEM + POSITION_0_CHECKER + POSITION_0_PLAYER_ROW;

        if (index > 3) position.z += 0.15f;

        if (index % 4 == 0) index = 0;
        if (index % 4 == 1) index = 1;
        if (index % 4 == 2) index = 2;
        if (index % 4 == 3) index = 3;

        // offset of 0.15f between each ball of the same row
        position.x += index * 0.15f; 

        return position;
    }

    public static Vector3 GetLocalPosition(Vector3 position)
    {
        return player_camera.ScreenToViewportPoint(position);
    }

    public static bool IsFullDigit(string s)
    {
        foreach (char c in s) if (!char.IsDigit(c)) return false;

        return true;
    }
}
