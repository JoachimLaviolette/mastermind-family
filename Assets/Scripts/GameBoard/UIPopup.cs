using UnityEngine;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{
    private Text m_title, m_message;

    private void Awake()
    {
        this.m_title = this.GetComponentsInChildren<Text>()[0];
        this.m_message = this.GetComponentsInChildren<Text>()[1];
    }

    /**
     * Setup the body of the popup
     */
    public void Setup(string title, string message)
    {
        this.m_title.text = title;
        this.m_message.text = message;
    }
}
