using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Ball : MonoBehaviour, IPointerClickHandler
{
    private BallManager.Color m_color;
    private int m_index;
    private Material m_mat;
    private Row m_parent_row;
    private bool is_opponent, is_colored;
    public static EventHandler e_OnClickColoredBall, e_OnClickBlankBall;

    private void Awake()
    {
        this.m_parent_row = this.GetComponentInParent<Row>();
        this.m_mat = this.GetComponent<MeshRenderer>().material;
        this.is_colored = false;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (this.is_opponent) return; // can only click player balls

        PlayerRow parent_row = (PlayerRow) this.m_parent_row;

        if (!parent_row.IsActive()) return; // not clickable

        if (this.is_colored) e_OnClickColoredBall.Invoke(this, EventArgs.Empty);
        else e_OnClickColoredBall.Invoke(this, EventArgs.Empty);
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

    public void SetIsColored(bool is_colored)
    {
        this.is_colored = is_colored;
    }

    public bool IsColored()
    {
        return this.is_colored;
    }
}
