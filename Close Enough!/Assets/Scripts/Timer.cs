using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public int timer = 30;

	public Text countdown;
	public Text timesUp;
	public Text waiting;

	public ScreenCapture screenCap;

	public ToolsSlide toolSlide;
	public DoneSlide doneSlide;
	public TimerSlide timerSlide;

	// Use this for initialization
	void Start () {
		timesUp.GetComponent<Text> ().enabled = false;
		waiting.enabled = false;
		StartCoroutine ("endTime");

	}
	
	// Update is called once per frame
	void Update () {
		if (timer < 0) {
			StopCoroutine ("endTime");
			StartCoroutine ("complete");

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

	IEnumerator complete() {
		timesUp.enabled = true;
		yield return new WaitForSeconds (3);
		timesUp.enabled = false;
		toolSlide.play = true;
		doneSlide.play = true;
		timerSlide.play = true;

		StartCoroutine ("screenshot");

	}

	IEnumerator screenshot() {
		yield return new WaitForSeconds (1);

		screenCap.done ();
		yield return new WaitForSeconds (3);

		screenCap.showImage ();

	}
}
