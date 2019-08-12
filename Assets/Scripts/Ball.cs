using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Ball : MonoBehaviour
{
    private BallManager.Color m_color;
    private int m_index;
    private Material m_mat;
    private Row m_parent_row;
    private bool is_opponent, is_colored, is_current;

    private void Awake()
    {
        this.m_parent_row = this.GetComponentInParent<Row>();
        this.m_mat = this.GetComponent<MeshRenderer>().material;
        this.is_colored = false;
    }

    private void Update()
    {
        this.CheckIsCurrent();
    }

    private void CheckIsCurrent()
    {
        if (this.is_current) this.TurnLight(true);
        else this.TurnLight(false);
    }

    private void TurnLight(bool on)
    {
        if (!on) if (!this.GetComponent<Light>()) return;
        if (on) if (this.GetComponent<Light>()) return;

        if (on) BallManager.AddBallLight(this);
        else Destroy(this.GetComponent<Light>());
    }

    /**
     * Set the ball color
     */
    public void SetColor(BallManager.Color color)
    {
        this.is_colored = true;
        this.m_color = color;
        this.SetMaterialColor();
    }

    /**
     * Set the ball material color
     */
    private void SetMaterialColor()
    {
        this.m_mat.color = BallManager.GetColor(this.m_color);
    }

    /**
     * Return the index of the ball
     */
    public int GetIndex()
    {
        return this.m_index;
    }

    /**
     * Set the index of the ball
     */
    public void SetIndex(int index)
    {
        this.m_index = index;
    }

    /**
     * Set the nature of the ball 
     */
    public void SetIsOpponent(bool is_opponent)
    {
        this.is_opponent = is_opponent;
    }

    /**
     * Set the ball parent row
     */
    public void SetParentRow(Row parent_row)
    {
        this.m_parent_row = parent_row;
    }

    /**
     * Set if the ball is colored
     */
    public void SetIsColored(bool is_colored)
    {
        this.is_colored = is_colored;
    }

    /**
     * Set if the ball is the current targeted
     */
    public void SetIsCurrent(bool is_current)
    {
        this.is_current = is_current;
    }

    /**
     * Return if the ball is colored
     */
    public bool IsColored()
    {
        return this.is_colored;
    }

    /**
     * Return if the ball is the current targetd
     */
    public bool IsCurrent()
    {
        return this.is_current;
    }

    /**
     * Return the index of the ball color
     */
    public int GetColorIndex()
    {
        if (!this.is_colored) new UnityException("Trying to access the color index of a non-colored ball.");

        return BallManager.GetColorIndex(this);
    }

    /**
     * Get the ball color
     */
    public BallManager.Color GetColor()
    {
        return this.m_color;
    }
}
