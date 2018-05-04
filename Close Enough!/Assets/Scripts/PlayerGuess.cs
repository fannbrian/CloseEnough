using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGuess : MonoBehaviour {

	public Text text;
	public string Guess;

	public void UpdateText() {
		Guess = text.text;
	}
}
