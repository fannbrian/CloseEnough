using UnityEngine;
using UnityEngine.UI;

public class DisplayRoomCode : MonoBehaviour {
	public Text roomName;
    
	public void InitializeRoomCode () {
		if (PhotonNetwork.room.Name.Length > 0) {
            roomName.text = "Room Code: " + PhotonNetwork.room.Name;
		} 
		else {
			roomName.text = "Error retrieving room ID";
		}
	}
}
