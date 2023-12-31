using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    public static NetworkManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            gameObject.SetActive(false);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }
    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    [PunRPC]
    public void ChangeScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }   

    public override void OnConnectedToMaster()
    {
        //CreateRoom("testroom");
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Created room: " + PhotonNetwork.CurrentRoom.Name);
    }

}