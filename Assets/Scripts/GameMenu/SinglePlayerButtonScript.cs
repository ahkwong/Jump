using UnityEngine;
using System.Collections;

public class SinglePlayerButtonScript : MonoBehaviour {

    void OnMouseDown()
    {
        Application.LoadLevel("SinglePlayer");
    }
}
