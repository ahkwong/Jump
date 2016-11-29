using UnityEngine;
using System.Collections;

public class MultiPlayerButtonScript : MonoBehaviour {
    public string name = "";
    void OnGUI()
    {
        name = GUI.TextField(new Rect(Screen.width / 2+25f, Screen.height / 2 + 35f, 80, 20f), name);
    }

    void OnMouseDown()
    {
        if (name != "")
        {
            Application.LoadLevel("MultiPlayer");
        }
    }
    void Update()
    {
        PlayerPrefs.SetString("PlayerName", name);
    }
}
