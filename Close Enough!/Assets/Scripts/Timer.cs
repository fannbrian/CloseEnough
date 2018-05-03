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
	private Boolean snap;

	public ToolsSlide toolSlide;
	public DoneSlide doneSlide;

	public AudioClip ticker;
	public AudioClip ding;

	AudioSource aud;
	Boolean playTick;
	Boolean playDing; 

	 public Button next;

	// Use this for initialization
	void Start () {
		snap = false;
		playTick = false;
		playDing = false;
		timesUp.enabled = false;
		waiting.enabled = false;
		next.gameObject.SetActive (false);
		aud = GetComponent<AudioSource> ();

		StartCoroutine ("endTime");

	}
	
	// Update is called once per frame
	void Update () {
		if (timer == 4 && !playTick) {
			aud.PlayOneShot (ticker, 1);
			playTick = true;
		}
		else if (timer < 0) {
			if (!snap && !playDing) {
				aud.PlayOneShot (ding, 1);

				StopCoroutine ("endTime");
				StartCoroutine ("complete");
				playDing = true;
			}

		} 
		else if (timer < 10) {
			countdown.text = ":0" + timer;
		} 
		else {
			countdown.text = ":" + timer;
		}
	}

	IEnumerator endTime() {
		yield return new WaitForSeconds (6);

		while (true) {
			yield return new WaitForSeconds (1);
			timer--;
		}
	}

	IEnumerator complete() {
		waiting.enabled = false;
		snap = true;
		timesUp.enabled = true;
		yield return new WaitForSeconds (3);
		timesUp.enabled = false;
		toolSlide.play = true;
		doneSlide.play = true;

		StartCoroutine ("screenshot");

	}

	IEnumerator screenshot() {
		yield return new WaitForSeconds (1);

		screenCap.done ();
		yield return new WaitForSeconds (3);

		screenCap.showImage ();
		next.gameObject.SetActive (true);

	}


}
