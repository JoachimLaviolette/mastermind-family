using UnityEngine;

public abstract class Row : MonoBehaviour
{
    protected int m_nb_balls;
    protected Ball[] m_balls;
    protected GameObject go_Ball;

    protected void Awake()
    {
        this.go_Ball = AssetManager.instance.GetBall();
    }

    public abstract void Initialize(int nb_balls, int turn);
    protected abstract void SetupBall(int index);
}
