using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

    public bool test = false;
    public GameObject[] playercounts;
	void Update ()
    {
        playercounts = GameObject.FindGameObjectsWithTag("Player");
        if (playercounts.Length == 1)
        {
			//Application.loadedLevel("gameover");
            test = true;
        }
	}
}
