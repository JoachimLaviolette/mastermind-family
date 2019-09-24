using System.Collections.Generic;
using UnityEngine;

public class OpponentRow : Row
{
    public override void Initialize(int nb_balls, int turn)
    {
        base.Initialize(nb_balls, turn);

        // We reverse the order 
        for (int x = this.m_nb_balls - 1; x >= 0; x--) this.SetupBall(x);
    }

    protected override void SetupBall(int index)
    {
        // Retrieve the proper position of the ball according to the provided index
        Vector3 position = Utils.GetBallPosition(index, true);

        // Create the ball
        Transform ts_Ball = Instantiate(this.go_Ball.transform, position, Quaternion.identity);
        Ball ball = ts_Ball.GetComponent<Ball>();

        // Attach the ball to the opponent row parent
        ball.transform.parent = this.transform;

        // Select a random color
        int random_index = Random.Range(0, 8);
        BallManager.Color color = BallManager.GetColor(random_index);

        // Setup the ball
        ball.SetIndex(index);
        ball.SetColor(color);
        ball.SetParentRow(this);
        ball.SetIsOpponent(true);

        // Add the current ball to the record
        this.m_balls.Add(ball);
    }

    /**
     * Return the count of color found in the opponent row
     */
    private int CountColor(BallManager.Color ball_color)
    {
        int sum = 0;

        foreach (Ball ball in this.m_balls)
            if (ball.GetColor() == ball_color) sum++;

        return sum;
    }

    /**
     * Return if a color still has to be well placed or not
     */
    public bool IsColorFullyFound(BallManager.Color ball_color, PlayerRow current_player_row)
    {
        int color_count = this.CountColor(ball_color);
        List<Ball> player_balls = current_player_row.GetBalls();

        for (int x = 0, y = this.m_balls.Count - 1; x < this.m_balls.Count; x++, y--)
            if (player_balls[x].GetColor() == ball_color && player_balls[x].Equals(this.m_balls[y]))
                color_count--;

        return color_count == 0;
    }
}
