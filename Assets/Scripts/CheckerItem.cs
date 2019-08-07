using UnityEngine;

public class CheckerItem : MonoBehaviour
{
    private int m_index;

    public int GetIndex()
    {
        return this.m_index;
    }

    public void SetIndex(int index)
    {
        this.m_index = index;
    }
}
