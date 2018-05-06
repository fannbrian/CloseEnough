﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloseEnough {
	public class GameInformation : MonoBehaviour {

		public static GameInformation _instance;

		// Number of players decides number of rounds
		public static int rounds;

		void Start() {
			rounds = 1;
		}
		void Update() {
			rounds = PhotonNetwork.playerList.Length;
		}

		public static GameInformation instance {
			get {
				if(_instance == null) {
					_instance = GameObject.FindObjectOfType<GameInformation>();
					DontDestroyOnLoad(_instance.gameObject);
				}
				return _instance;
			}
		}


		void Awake() {
			DontDestroyOnLoad (this);

			// Creates a game info singleton
			if(_instance == null) {
				_instance = this;
				DontDestroyOnLoad(this);
			}
			else {
				//Destroy any other instances of Singleton
				if(this != _instance)
					Destroy(this.gameObject);
			}
		}
	}
}