using UnityEngine;
using System.Collections.Generic;

public class PlayerMovementOnline : Photon.MonoBehaviour
{
    public Vector3 movement;
    public Vector3 mousepos;
    public float horizontal;
    public bool jump = false;
    public bool canjump = true;
    public float jumppower;
    public float playerspeed;
    public bool flag;
    public bool canclick = true;

    void FixedUpdate()
    {
        if (photonView.isMine)
        {
            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if ((mousepos.x - transform.position.x) > 0.1)
            { horizontal = 1; }
            else
            {
                if ((mousepos.x - transform.position.x) < -0.1)
                { horizontal = -1; }
                else
                { horizontal = 0; }
            }
            jump = Input.GetMouseButtonDown(0);
            if (jump&&canclick)
            {
                flag = !flag;
            }
            Move(horizontal);
        }
        else
        {
            SyncMovement();
        }
    }
    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;
    private void SyncMovement()
    {
        syncTime += Time.deltaTime;
        GetComponent<Rigidbody>().position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
    }
    void Move(float h)
    {
        movement.Set(h, 0f, 0f);
        movement = movement.normalized * playerspeed * Time.deltaTime;
        GetComponent<Rigidbody>().MovePosition(transform.position + movement);
    }
    void OnCollisionEnter()
    {
        if (photonView.isMine)
        {
            canjump = true;
        }
    }
    void OnTriggerEnter()
    {
        if (photonView.isMine)
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumppower;
        }
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(GetComponent<Rigidbody>().position);
            stream.SendNext(GetComponent<Rigidbody>().velocity);
        }
        else
        {
            Vector3 syncPosition = (Vector3)stream.ReceiveNext();
            Vector3 syncVelocity = (Vector3)stream.ReceiveNext();
            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime;
            lastSynchronizationTime = Time.time;
            syncEndPosition = syncPosition + syncVelocity * syncDelay;
            syncStartPosition = GetComponent<Rigidbody>().position;
        }
    }
}
