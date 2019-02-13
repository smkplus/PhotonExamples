using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Item : MonoBehaviourPun {

private void OnTriggerEnter(Collider other) {
if(other.gameObject.GetComponent<PhotonView>().IsMine){
	other.gameObject.GetComponent<PlayerScore>().Score += 5;
}
//photonView.RPC("DestroyItem",RpcTarget.All,gameObject.name);
PhotonNetwork.Destroy(gameObject);
}

// [PunRPC]
// void DestroyItem(string name){
// var target = GameObject.Find(name);
// if(target != null){
// Destroy(target);
// }
// }

}

