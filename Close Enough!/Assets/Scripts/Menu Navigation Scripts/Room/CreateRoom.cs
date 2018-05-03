using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviour {

	public void OnClick_CreateRoom(){
		if (PhotonNetwork.CreateRoom (null)) {
			print ("create room successfully sent.");
		} 
		else {
			print ("create room failed to send.");
		}
	}

	private void OnPhotonCreateRoomFailed(object[] codeAndMessage){
		print("Create room failed: " + codeAndMessage[1]);
	}

	private void OnCreatedRoom(){
		print ("Room created successfully. TESTING randomized roomname = " + PhotonNetwork.room.Name);
	}
}
