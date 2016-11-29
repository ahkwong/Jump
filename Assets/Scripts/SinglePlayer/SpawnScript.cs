using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject Floor;
    public float range = 10f;
    private float repeatRate = 0.35f;

	void Start () {
        InvokeRepeating("Spawn", 0f, repeatRate);
	}
    void Spawn()
    {
        //Instantiate(Floor, new Vector3(Random.Range(-3f, 3f), 6f, 0f), Quaternion.identity);
        GameObject Jumper = GameObject.Instantiate(Floor, new Vector3(Random.Range(-range, range), 6f, 0f), Quaternion.identity) as GameObject;
        Jumper.name = "Jumper";
    }
}
