using UnityEngine;
using System.Collections;

public class StartingFloorScript : MonoBehaviour
{

    public float angle;
    public float x;
    public float y;
    public float radius;
    public Vector3 spawn;
    public Vector3 spawnh;
    public GameObject Floor;
    float speed = 1f;

    /*void Awake()
    {
        if (transform.position.y < 10)
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
    }*/
    void Awake()
    {
        StartCoroutine(remove());
    }
    void FixedUpdate()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }
    IEnumerator remove()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }
}
