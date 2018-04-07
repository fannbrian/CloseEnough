using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public int timer = 30;

	public Text countdown;
	public Text timesUp;

	public ScreenCapture screenCap;

	// Use this for initialization
	void Start () {
		timesUp.enabled = false;
		StartCoroutine ("endTime");

	}
	
	// Update is called once per frame
	void Update () {
		if (timer < 0) {
			StopCoroutine ("endTime");
			screenCap.done ();

			timesUp.enabled = true;
		} else if (timer < 10) {
			countdown.text = ":0" + timer;
		} else {
			countdown.text = ":" + timer;
		}
	}

	IEnumerator endTime() {
		while (true) {
			yield return new WaitForSeconds (1);
			timer--;
		}
	}
}
