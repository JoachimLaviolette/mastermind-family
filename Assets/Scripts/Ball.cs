using UnityEngine;

public class Ball : MonoBehaviour
{
    private BallManager.Color m_color;
    private int m_index;
    private Material m_mat;

    private void Awake()
    {
        this.m_mat = this.GetComponent<MeshRenderer>().material;
    }

    /**
     * Set the ball color
     */
    public void SetColor(BallManager.Color color)
    {
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
}
