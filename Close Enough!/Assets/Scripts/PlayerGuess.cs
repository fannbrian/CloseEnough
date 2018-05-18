using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Collect a player's guess
/// </summary>
public class PlayerGuess : MonoBehaviour {

	public Text text;
	public string Guess;

	public void UpdateText() {
		Guess = text.text;
	}
}
