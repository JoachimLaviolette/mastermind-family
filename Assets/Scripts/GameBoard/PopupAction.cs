using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupAction : MonoBehaviour
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

    public void Continue()
    {
        SceneManager.LoadScene(AssetManager.SCENE_GAME_MAIN_MENU);
    }
}
