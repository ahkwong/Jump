using UnityEngine;
using System.Collections;

public class OnlineCamera : Photon.MonoBehaviour {

    void FixedUpdate()
    {
        if (photonView.isMine)
        {
            Vector3 cposition = new Vector3(0f, GameObject.Find(PlayerPrefs.GetString("PlayerName")).GetComponent<Transform>().position.y, -1f);
            transform.position = Vector3.Lerp(transform.position, cposition, 2f * Time.deltaTime);
        }
    }
}
