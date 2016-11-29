using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class BackgroundScript : MonoBehaviour {

    private float speed = 0.3f;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

}
