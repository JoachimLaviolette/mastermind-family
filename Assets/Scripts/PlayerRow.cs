using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRow : Row
{
    private bool is_active;

    public override void Initialize(int nb_balls, int turn)
    {
        this.m_nb_balls = nb_balls;
        this.is_active = true;

        for (int x = 0; x < this.m_nb_balls; x++) this.SetupBall(x);

        this.SetupChecker();
        Utils.SetupPlayerRowPositionOnBoard(this, turn);
    }

    protected override void SetupBall(int index)
    {
        // Retrieve the proper position
        Vector3 position = Utils.GetBallPosition(index, false);

        // Create the ball game object
        Transform ts_Ball = Instantiate(this.go_Ball.transform, position, Quaternion.identity);
        Ball ball = ts_Ball.GetComponent<Ball>();        

        // Attach the newly-created ball to the player row parent
        ball.transform.parent = this.transform;

        // Setup the ball
        ball.SetIndex(index);
    }

    private void SetupChecker()
    {
        GameObject go_Checker = AssetManager.instance.GetChecker();
        // Retrieve the proper position
        Vector3 position = Utils.GetCheckerPosition();

        // Create the checker game object
        Transform ts_Checker = Instantiate(go_Checker.transform, position, Quaternion.identity);
        Checker checker = ts_Checker.GetComponent<Checker>();

        // Attach the newly-created checker to the opponent row parent
        checker.transform.parent = this.transform;

        // Setup the checker
        checker.Initialize(this.m_nb_balls);
    }
}
