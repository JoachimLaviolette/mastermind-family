using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager instance;
    private static Dictionary<Color, UnityEngine.Color> color_values;
    private static Dictionary<int, Color> color_index;

    // Complex colors
    private const string COLOR_HTML_PURPLE = "#642d9c";
    private const string COLOR_HTML_PINK = "#db8ade";
    private const string COLOR_HTML_ORANGE = "#ff6f00";

    public enum Color
    {
        Red,
        Green,
        Blue,
        Yellow,
        Orange,
        Purple,
        Pink,
        Cyan,
        Black,
    }

    private void Awake()
    {
        instance = this;
        InitializeColorRef();
        InitializeColorRefIndex();
    }

    /**
     * Initialize the color ref dictionary
     */
    private static void InitializeColorRef()
    {
        color_values = new Dictionary<Color, UnityEngine.Color>();
        color_values.Add(Color.Red, UnityEngine.Color.red);
        color_values.Add(Color.Green, UnityEngine.Color.green);
        color_values.Add(Color.Blue, UnityEngine.Color.blue);
        color_values.Add(Color.Yellow, UnityEngine.Color.yellow);
        color_values.Add(Color.Black, UnityEngine.Color.black);
        color_values.Add(Color.Cyan, UnityEngine.Color.cyan);

        InitializeComplexColors();
    }

    /**
     * Initialize the complex colors
     */
    private static void InitializeComplexColors()
    {
        UnityEngine.Color color;

        // Orange
        ColorUtility.TryParseHtmlString(COLOR_HTML_PURPLE, out color);
        color_values.Add(Color.Purple, color);
        // Purple
        ColorUtility.TryParseHtmlString(COLOR_HTML_ORANGE, out color);
        color_values.Add(Color.Orange, color);
        // Pink
        ColorUtility.TryParseHtmlString(COLOR_HTML_PINK, out color);
        color_values.Add(Color.Pink, color);
    }

    /**
     * Initialize the color ref indices
     */
    private static void InitializeColorRefIndex()
    {
        color_index = new Dictionary<int, Color>();
        color_index.Add(0, Color.Red);
        color_index.Add(1, Color.Green);
        color_index.Add(2, Color.Blue);
        color_index.Add(3, Color.Yellow);
        color_index.Add(4, Color.Black);
        color_index.Add(5, Color.Cyan);
        color_index.Add(6, Color.Purple);
        color_index.Add(7, Color.Orange);
        color_index.Add(8, Color.Pink);
    }

    /**
     * Get a UnityEngine color from a color
     */
    public static UnityEngine.Color GetColor(Color color)
    {
        return color_values[color];
    }

    /**
     * Get a color from a specific index
     */
    public static Color GetColor(int index)
    {
        return color_index[index];
    }

    /**
     * Get the colors
     */
    public static Dictionary<int, Color> GetColors()
    {
        return color_index;
    }

    /**
     * Get the current ball light component
     */
    public static void AddBallLight(Ball ball)
    {
        Light ball_light = ball.gameObject.AddComponent<Light>();
        ball_light.type = LightType.Point;
        ball_light.color = UnityEngine.Color.white;
        ball_light.intensity = 2.5f;
        ball_light.lightmapBakeType = LightmapBakeType.Realtime;
    }

    /**
     * Dyanmically set the given color to the given ball
     */
    public static void SetColor(Ball ball, Color color)
    {
        ball.GetComponent<MeshRenderer>().material.color = GetColor(color);
    }

    /**
     * Get the color index of the specified ball
     */
    public static int GetColorIndex(Ball ball)
    {
        for (int i = 0; i < color_index.Count; i++)
            if (color_index[i] == ball.GetColor()) return i;

        return 0;
    }
}
