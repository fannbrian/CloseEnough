using UnityEngine;
using UnityEngine.UI;
using Photon;

public class DisplayRoomCode : PunBehaviour {

	public Text roomName;

	// Use this for initialization
	public override void OnJoinedRoom () {
		if (PhotonNetwork.room.Name.Length > 0) {
            roomName.text = "Room Code: " + PhotonNetwork.room.Name;
		} 
		else {
			roomName.text = "Error retrieving room ID";
		}
	}
}
