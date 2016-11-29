using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {

    public float angle;
    public float x;
    public float y;
    public float radius;
    public Vector3 spawn;
    public Vector3 spawnh;
    public GameObject Floor;
    public GameObject EndFloor;
    float speed = 2f;

    /*void Awake()
    {
        if (transform.position.y < 300)
        {
            radius = Random.Range(2f, 3.5f);
            angle = Random.Range(0f, 3.1416f);
            x = radius * Mathf.Cos(angle);
            y = radius * Mathf.Sin(angle);
            spawn.Set(x, y, 0f);
            spawnh.Set(0f, transform.position.y, 0f);
            GameObject Jumper = GameObject.Instantiate(Floor, spawnh + spawn, Quaternion.identity) as GameObject;
            Jumper.name = "Jumper";
        }
        else
        {
            spawnh.Set(0f, transform.position.y + 3f, 0f);
            GameObject End = GameObject.Instantiate(EndFloor, spawnh, Quaternion.identity) as GameObject;
            End.name = "EndFloor";
        }
    }*/
    void Awake()
    {
        StartCoroutine(remove());
    }
    void FixedUpdate()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }
    void OnTriggerExit()
    {
        Destroy(gameObject);
    }
    IEnumerator remove()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }
}
