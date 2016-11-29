using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal;
    public Vector3 mousepos;
    public Vector3 movement;
    public float playerspeed=5f;
    public float jumppower=8f;
    public string player;
    void FixedUpdate()
    {

        horizontal = Input.GetAxisRaw(player + " Horizontal");

        /*mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if ((mousepos.x - transform.position.x) > 0.1)
        { horizontal = 1; }
        else
        {
            if ((mousepos.x - transform.position.x) < -0.1)
            { horizontal = -1; }
            else
            { horizontal = 0; }
        }*/
        Move(horizontal);
    }
    void Move(float h)
    {
        movement.Set(h, 0f, 0f);
        movement = movement.normalized * playerspeed * Time.deltaTime;
        GetComponent<Rigidbody>().MovePosition(transform.position + movement);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "StartingFloor")
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumppower;
        }
        if (col.gameObject.name == "Jumper")
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumppower;
        }
    }
}

/*using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;
 
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
 
    private Rigidbody2D rb;
 
    // This should be either p1, p2, p3, p4
    public string player;
 
    public float speed = 3f;
 
    public bool horizontalMovement;
    public bool verticalMovement;
 
        // Use this for initialization
        void Start ()
        {
 
            rb = GetComponent<Rigidbody2D>();
 
        }
       
        // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw(player + " Horizontal");
        float v = Input.GetAxisRaw(player + " Vertical");
 
        Move(h, v);
    }
 
    void Update()
    {
        if (Input.GetButtonDown(player + " Action"))
        {
            Jump();
        }
    }
 
    private void Move(float h, float v)
    {
       
       Vector3 movement = new Vector3(h,v,0f);
       movement = movement.normalized * speed * Time.deltaTime;
       rb.MovePosition(transform.position + movement);
           
       
    }
 
    void Jump()
    {
        Debug.Log(player + " pressed action button!");
    }
}*/