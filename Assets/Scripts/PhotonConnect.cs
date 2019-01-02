using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    public GameObject ConnectingMenu;
    public GameObject MainMenu;

    public GameObject Prefab;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        print("Connecting...");
    }

    public override void OnConnectedToMaster()
    {
       
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        print("Connected");
        ConnectingMenu.SetActive(false);
        MainMenu.SetActive(true);

    }

    public override void OnJoinedLobby()
    {
        print("On Joined Lobby");


    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(Prefab.name, Vector3.zero, Prefab.transform.rotation);

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("DisconnectFrom Photon");
        ConnectingMenu.SetActive(true);
        MainMenu.SetActive(false);

    }
}
