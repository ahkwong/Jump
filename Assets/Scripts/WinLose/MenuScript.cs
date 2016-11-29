using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    void OnMouseDown()
    {
        Application.LoadLevel("GameMenu");
    }
}
