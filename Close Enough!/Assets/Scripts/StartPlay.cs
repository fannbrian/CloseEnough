using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPlay : MonoBehaviour {

	public Text word;
	public Text countdown;

	bool wordDisplay;
	bool countdownDisplay;
	int counting;

	// Use this for initialization
	void Start () {
		counting = 3;
		countdown.enabled = true;

		StartCoroutine ("count");

	}

	IEnumerator displayWord() {
		yield return new WaitForSeconds (1);
		StartCoroutine ("count");
	}

	IEnumerator count() {
		while (counting >= 0) {
			yield return new WaitForSeconds (1);
			if (counting == 3) {
				countdown.text = "3";
			}
			else if (counting == 2) {
				countdown.text = "2";
			}
			else if (counting == 1) {
				countdown.text = "1";
			}
			counting--;
		}
		countdown.enabled = false;
        word.enabled = false;
	}
}
