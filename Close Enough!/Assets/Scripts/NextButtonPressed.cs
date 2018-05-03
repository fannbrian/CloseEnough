using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButtonPressed : MonoBehaviour {

	public void goToLobby() {
		SceneManager.LoadScene ("Lobby", LoadSceneMode.Additive);
	}
}
