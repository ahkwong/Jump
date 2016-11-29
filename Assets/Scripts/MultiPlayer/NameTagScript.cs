using UnityEngine;
using System.Collections;

public class NameTagScript : Photon.MonoBehaviour
{
    public string SendNameTag;
    public string SavedNameTag;
    public string OtherNameTag;
    public string tag="Idle";
    void Start()
    {
        SavedNameTag = GetComponent<TextMesh>().text;
    }
    void FixedUpdate()
    {
        if (photonView.isMine)
        {
            SendNameTag = SavedNameTag;
            if (transform.GetComponentInParent<PlayerMovementOnline>().flag)
            {
                SendNameTag = "READY!";
                gameObject.tag = "Ready";
                GetComponent<TextMesh>().text = "READY!";
            }
            else
            {
                SendNameTag = SavedNameTag;
                gameObject.tag = "Idle";
                GetComponent<TextMesh>().text = SavedNameTag;
            }
        }
        else
        {
            gameObject.tag = tag;
            GetComponent<TextMesh>().text = OtherNameTag;
        }
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(GetComponent<TextMesh>().text);
            stream.SendNext(gameObject.tag);
        }
        else
        {
            OtherNameTag = (string)stream.ReceiveNext();
            tag = (string)stream.ReceiveNext();
        }
    }
}
