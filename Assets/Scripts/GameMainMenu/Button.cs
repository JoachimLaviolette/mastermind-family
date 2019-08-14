using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public string button_name;
    [Range(20, 40)] public int font_size;
    public Font font;
    private Text m_text;
    
    private void Awake()
    {
        this.m_text = this.GetComponentInChildren<Text>();
    }

    private void Start()
    {
        this.m_text.text = button_name.ToUpper();
        this.m_text.fontSize = font_size;
        this.m_text.font = font;
    }

    public void Play()
    {
        SceneManager.LoadScene(AssetManager.SCENE_GAME_BOARD);
    }

    public void Credits()
    {
        // Load credits
    }

    public void Exit()
    {
        Application.Quit();
    }
}
