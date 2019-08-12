using System.Collections.Generic;
using UnityEngine;

public abstract class Row : MonoBehaviour
{
    protected int m_nb_balls;
    protected List<Ball> m_balls;
    protected GameObject go_Ball;

    protected void Awake()
    {
        this.go_Ball = AssetManager.instance.GetBall();
    }

    public virtual void Initialize(int nb_balls, int turn)
    {
        this.m_nb_balls = nb_balls;
        this.m_balls = new List<Ball>();
    }

    protected abstract void SetupBall(int index);
}
