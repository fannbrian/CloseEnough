using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPlay : MonoBehaviour {

	public Text word;
	public Text countdown;

	Boolean wordDisplay;
	Boolean countdownDisplay;
	int counting;

	// Use this for initialization
	void Start () {
		counting = 5;
		countdown.enabled = false;

		StartCoroutine ("displayWord");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator displayWord() {
		yield return new WaitForSeconds (4);
		word.enabled = false;
		StartCoroutine ("count");
	}

	IEnumerator count() {
		while (counting >= 0) {
			yield return new WaitForSeconds (1);
			if (counting == 5) {
				countdown.enabled = true;
				countdown.text = "Ready?";
			}
			else if (counting == 3) {
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
	}
}
