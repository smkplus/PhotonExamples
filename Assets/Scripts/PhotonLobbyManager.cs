using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLobbyManager : MonoBehaviour {
    public InputField createRoomInput, joinRoomInput;
    public GameObject LobbyMenu;

    public void CreateRoom()
    {
        if(createRoomInput.text.Length > 0)
        {
        PhotonNetwork.CreateRoom(createRoomInput.text,new RoomOptions() { MaxPlayers = 4 },null);
        print("Room Created");
            LobbyMenu.SetActive(false);
        }
    }

    public void JoinRoom()
    {
        print("JoinedRoom");

        if (joinRoomInput.text.Length > 0)
        {
            PhotonNetwork.JoinRoom(joinRoomInput.text);
            print("works");

        }
        LobbyMenu.SetActive(false);

    }
}
