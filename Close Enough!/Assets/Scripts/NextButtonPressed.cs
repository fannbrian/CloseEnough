using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CloseEnough {
	
	public class NextButtonPressed : MonoBehaviour {

		public Timer timer;

		public void goToLobby() {
			
			SceneManager.LoadScene ("Lobby");
		}
			
		public void continueGame() {
			timer.playing = false;
		}
	}

}