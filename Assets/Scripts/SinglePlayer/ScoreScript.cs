using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    public GameObject player;
    public GameObject camera;
    public float y;
    public float highscore=0;
    void FixedUpdate()
    {
        Vector3 position = new Vector3(camera.GetComponent<Transform>().position.x, camera.GetComponent<Transform>().position.y, 0f);
        transform.position = position + new Vector3(3f, 4.5f, 0f);
        if (player != null)
        {
            y = player.GetComponent<Transform>().position.y;
        }
        if (highscore < y)
        {
            highscore = y;
        }
        GetComponent<TextMesh>().text = "Score: "+highscore.ToString("0.00");
        PlayerPrefs.SetFloat("PlayerScore", highscore);
    }
}
