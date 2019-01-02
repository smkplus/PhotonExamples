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
            LobbyMenu.SetActive(false);
        }
    }

    public void JoinRoom()
    {
        if (joinRoomInput.text.Length > 0)
        {
            PhotonNetwork.JoinRoom(createRoomInput.text);
        }
        LobbyMenu.SetActive(false);

    }
}
