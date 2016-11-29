using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour {

    void OnMouseDown()
    {
        Application.LoadLevel("SinglePlayer");
    }
}
