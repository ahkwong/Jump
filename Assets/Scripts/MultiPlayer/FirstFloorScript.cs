using UnityEngine;
using System.Collections;

public class FirstFloorScript : MonoBehaviour {

    public float angle;
    public float x;
    public float y;
    public float radius;
    public Vector3 spawn;
    public Vector3 spawnh;
    void OnTriggerEnter()
    {
        if (transform.position.y < 300)
        {
            radius = Random.Range(2f, 3.5f);
            angle = Random.Range(0f, 3.1416f);
            x = radius * Mathf.Cos(angle);
            y = radius * Mathf.Sin(angle);
            spawn.Set(x, y, 0f);
            spawnh.Set(0f, transform.position.y, 0f);
            PhotonNetwork.Instantiate("Jumper", spawn + spawnh, Quaternion.identity, 0);
        }
    }
}
