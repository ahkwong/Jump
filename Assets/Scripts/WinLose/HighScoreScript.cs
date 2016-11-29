using UnityEngine;
using System.Collections;

public class HighScoreScript : MonoBehaviour {

    public float highscore;
    void Update()
    {
        highscore = PlayerPrefs.GetFloat("PlayerScore",0.00f);
        GetComponent<TextMesh>().text = "Score: " + highscore.ToString("0.00");
    }
}
