using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CloseEnough {

	/// <summary>
	/// After a round is completed, load the Lobby
	/// 
	/// (unused)
	/// </summary>
	public class NextButtonPressed : MonoBehaviour {

		public void goToLobby() {
			SceneManager.LoadScene ("Lobby");
		}
	}

}