using UnityEngine;
using System.Collections;

public class LobbyScript : Photon.MonoBehaviour
{
    public GameObject countdown;
    public bool test = false;
    public bool canstart = true;
    public GameObject[] playercounts;
    void Start()
    {
        Instantiate(countdown, Vector3.zero, Quaternion.identity);
        GameObject.Find("CountDown(Clone)").GetComponent<Renderer>().enabled = false;
    }
    void Update()
    {
        playercounts = GameObject.FindGameObjectsWithTag("Ready");
        if (playercounts.Length == 1&&canstart)
        {
            test = true;
            StartCoroutine(spawnlevel());
        }
        else
        {
            test = false;
        }
    }
    IEnumerator spawnlevel()
    {
        GameObject.Find("CountDown(Clone)").GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        GameObject.Find("CountDown(Clone)").GetComponent<TextMesh>().text = "3";
        yield return new WaitForSeconds(1f);
        GameObject.Find("CountDown(Clone)").GetComponent<TextMesh>().text = "2";
        yield return new WaitForSeconds(1f);
        GameObject.Find("CountDown(Clone)").GetComponent<TextMesh>().text = "1";
        yield return new WaitForSeconds(1f);
        GameObject.Find("CountDown(Clone)").GetComponent<TextMesh>().text = "0";
        yield return new WaitForSeconds(1f);
        GameObject.Find("CountDown(Clone)").GetComponent<Renderer>().enabled = false;
        GameObject.Find(PlayerPrefs.GetString("PlayerName")).GetComponent<PlayerMovementOnline>().flag = false;
        GameObject.Find(PlayerPrefs.GetString("PlayerName")).GetComponent<PlayerMovementOnline>().canclick = false;
        GameObject.Find("Ground").GetComponent<BoxCollider>().enabled = false;
        GameObject.Find("Ground").GetComponent<Renderer>().enabled = false;
        canstart = false;
    }
}
