using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /**
     * Create a new UI popup and with the provided params
     */
    public static void CreateUIPopup(string title, string message)
    {
        GameObject go_UI_popup = Instantiate(AssetManager.instance.GetUIPopup(), Vector3.zero, Quaternion.identity);
        UIPopup UI_popup = go_UI_popup.GetComponent<UIPopup>();
        UI_popup.Setup(title, message);
    }
}
