using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class PlayerScore : MonoBehaviourPun,IPunObservable {
public Text ScoreText;
public float Score;


private void Update() {
	ScoreText.text = Score.ToString();
}


public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
{
	if(stream.IsWriting){
	stream.SendNext(Score);
	}else{
	Score = (float)stream.ReceiveNext();	
	}
}
}
