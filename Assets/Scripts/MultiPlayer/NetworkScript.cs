using UnityEngine;
using System.Collections;

public class NetworkScript : Photon.MonoBehaviour
{

    public bool offlinemode = false;
    public string name;
    public Vector3 Origin = new Vector3(0f, 0f, 0f);

    void Start()
    {
        if (offlinemode)
        {
            PhotonNetwork.offlineMode = true;
            OnJoinedLobby();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings("Alpha 0.1");
        }
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null,true,true,4);
    }

    void OnJoinedRoom()
    {
        name = PlayerPrefs.GetString("PlayerName");
        GameObject player = PhotonNetwork.Instantiate("PlayerCubeOnline", Origin, Quaternion.identity, 0);
        player.name = name;
        player.GetComponentInChildren<TextMesh>().text = name;
    }

}
