using UnityEngine;
using System.Collections;

public class EndFloorScript : MonoBehaviour
{
    void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.name == "PlayerCube")
            Destroy(player.gameObject);
        Application.LoadLevel("Win");
    }
}
