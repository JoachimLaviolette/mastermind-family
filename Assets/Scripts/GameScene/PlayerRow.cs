using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRow : Row
{
    private Checker m_checker;
    private bool is_active;

    /**
     * Initialize the player row
     */
    public override void Initialize(int nb_balls, int turn)
    {
        base.Initialize(nb_balls, turn);
        this.is_active = true;

        for (int x = 0; x < this.m_nb_balls; x++) this.SetupBall(x);

        this.SetupChecker();
        Utils.SetupPlayerRowPositionOnBoard(this, turn);
    }

    /**
     * Initialize the ball at the specified index
     */
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
        ball.SetParentRow(this);
        ball.SetIsOpponent(false);

        // Add the current ball to the record
        this.m_balls.Add(ball);
    }

    /**
     * Setup the checker of the row
     */
    private void SetupChecker()
    {
        GameObject go_Checker = AssetManager.instance.GetChecker();
        // Retrieve the proper position
        Vector3 position = Utils.GetCheckerPosition();

        // Create the checker game object
        Transform ts_Checker = Instantiate(go_Checker.transform, position, Quaternion.identity);
        this.m_checker = ts_Checker.GetComponent<Checker>();

        // Attach the newly-created checker to the opponent row parent
        this.m_checker.transform.parent = this.transform;

        // Setup the checker
        this.m_checker.Initialize(this.m_nb_balls);
    }

    /**
     * Return if the row is the active one
     */
    public bool IsActive()
    {
        return this.is_active;
    }

    /**
     * Set the current player row as active or not
     */
    public void SetIsActive(bool is_active)
    {
        this.is_active = is_active;
    }

    /**
     * Get the ball at the specified index
     */
    public Ball GetBall(int ball_index)
    {
        if (ball_index < 0 || ball_index > this.m_balls.Count) new UnityException("Trying to get a ball out of the list bounds.");
        if (!this.is_active) new UnityException("Trying to get a ball from an unactive row.");

        return this.m_balls[ball_index];
    }

    /**
     * Return if the player row is fully colored or not
     */
    public bool IsFull()
    {
        foreach (Ball ball in this.m_balls)
            if (!ball.IsColored()) return false;

        return true;
    }

    /**
     * Update the checker of the player row
     */
    public void UpdateChecker(int checker_item_index, bool is_good_pos, bool is_color_exist)
    {
        this.m_checker.UpdateCheckerItem(checker_item_index, is_good_pos, is_color_exist);
    }
}
