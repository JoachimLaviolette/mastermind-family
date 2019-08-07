using UnityEngine;

public class OpponentRow : Row
{
    public override void Initialize(int nb_balls, int turn)
    {
        this.m_nb_balls = nb_balls;

        // We reverse the order 
        for (int x = this.m_nb_balls - 1; x >= 0; x--) this.SetupBall(x);
    }

    protected override void SetupBall(int index)
    {
        // Retrieve the proper position
        Vector3 position = Utils.GetBallPosition(index, true);

        // Create the ball game object
        Transform ts_Ball = Instantiate(this.go_Ball.transform, position, Quaternion.identity);
        Ball ball = ts_Ball.GetComponent<Ball>();

        // Attach the newly-created the ball to the opponent row parent
        ball.transform.parent = this.transform;

        // Select a random color
        int random_index = Random.Range(0, 8);
        BallManager.Color color = BallManager.GetColor(random_index);

        // Setup the ball
        ball.SetIndex(index);
        ball.SetColor(color);
        ball.SetParentRow(this);
        ball.SetIsOpponent(true);
    }
}
