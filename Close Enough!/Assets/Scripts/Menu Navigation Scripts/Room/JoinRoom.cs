﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JoinRoom : MonoBehaviour {

	public Text roomName;

	public void OnClick_JoinRoom(){
		if (PhotonNetwork.JoinRoom(roomName.text)) {
		} 
		else {
			print ("Joint room failed.");
		}

	}
}
	