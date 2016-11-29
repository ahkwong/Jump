using UnityEngine;
using System.Collections;

public class KillGround : MonoBehaviour {

    public GameObject camera;
    public Vector3 camerapos;
    void FixedUpdate()
    {
        camerapos = camera.GetComponent<Transform>().position;
        camerapos.y = camerapos.y - 6;
        camerapos.z = 0;
        transform.position = camerapos;
    }
	void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            //Application.LoadLevel("GameOver");
        }
    }
}
