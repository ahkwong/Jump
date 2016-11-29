using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    float speed = 2f;
    public GameObject player;
    void FixedUpdate()
    {
        //transform.position += Vector3.up * Time.deltaTime * speed;
        /*if (player != null)
        {
            Vector3 cposition = new Vector3(0f, player.GetComponent<Transform>().position.y, -1f);
            transform.position = Vector3.Lerp(transform.position, cposition, 2f * Time.deltaTime);
        }*/
    }
}
