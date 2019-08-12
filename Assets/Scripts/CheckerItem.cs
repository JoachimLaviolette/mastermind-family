using System.Collections.Generic;
using UnityEngine;

public class CheckerItem : MonoBehaviour
{
    private int m_index;
    private static Dictionary<Color, UnityEngine.Color> color_values;

    private enum Color
    {
        OK,
        COLOR_EXIST,
        NOT_OK,
    }

    private void Awake()
    {
        InitializeColorValues();
    }

    private static void InitializeColorValues()
    {
        color_values = new Dictionary<Color, UnityEngine.Color>();
        color_values.Add(Color.OK, UnityEngine.Color.green);
        color_values.Add(Color.COLOR_EXIST, UnityEngine.Color.yellow);
        color_values.Add(Color.NOT_OK, UnityEngine.Color.red);
    }

    /**
     * Get the checker item index
     */
    public int GetIndex()
    {
        return this.m_index;
    }

    /**
     * Set the checker item index
     */
    public void SetIndex(int index)
    {
        this.m_index = index;
    }

    /**
     * Update the checker item data according to the providing params
     */
    public void UpdateData(bool is_good_pos, bool is_color_exist)
    {
        if (is_good_pos)
        {
            this.SetColor(Color.OK);

            return;
        }

        if (is_color_exist)
        {
            this.SetColor(Color.COLOR_EXIST);

            return;
        }

        this.SetColor(Color.NOT_OK);
    }

    /**
     * Dyanmically set the given color to the given ball
     */
    private void SetColor(Color color)
    {
        this.GetComponent<MeshRenderer>().material.color = GetColor(color);
    }

    /**
     * Get a UnityEngine color from a color
     */
    private UnityEngine.Color GetColor(Color color)
    {
        return color_values[color];
    }
}
