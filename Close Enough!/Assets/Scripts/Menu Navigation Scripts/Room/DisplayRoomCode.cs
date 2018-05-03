using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayRoomCode : MonoBehaviour {

	public Text roomName;

	// Use this for initialization
	void Start () {
		if (PhotonNetwork.room.Name.Length > 0) {
			roomName.text = PhotonNetwork.room.Name;
		} 
		else {
			roomName.text = "Error retrieving room ID";
		}
	}
}
