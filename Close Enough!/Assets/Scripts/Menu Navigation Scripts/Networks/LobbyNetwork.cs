using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
public class LobbyNetwork : PunBehaviour {

	// Use this for initialization
	void Start () {
		print ("Connecting to server..");
		PhotonNetwork.ConnectUsingSettings("0.0.0");
	}

	public override void OnConnectedToMaster(){
		print ("Connected to master.");
		PhotonNetwork.playerName = PlayerNetwork.Instance.PlayerName;
        Debug.Log("RECEIVED: "+PlayerNetwork.Instance.PlayerName);
		PhotonNetwork.JoinLobby(TypedLobby.Default);
	}
}
