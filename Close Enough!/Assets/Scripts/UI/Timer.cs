using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough {
	public class Timer : MonoBehaviour {
		public int timer = 30;
		public int starttimer = 3;

		bool countdownDisplay;

		public Text startcountdown;
		public Text countdown;
		public Text timesUp;
		public Text waiting;

		public bool running = false;
		public bool done = false;

		public AudioClip ticker;
		public AudioClip ding;

		AudioSource aud;
		Boolean playTick;
		Boolean playDing;
      
		// Use this for initialization
		void Awake () {
			playTick = false;
			playDing = false;
			startcountdown.gameObject.SetActive (false);
			timesUp.gameObject.SetActive (false);
			waiting.gameObject.SetActive (false);
			aud = GetComponent<AudioSource> ();         
		}

		// Update is called once per frame
		void Update () {
			if (timer <= 3 && !playTick) {
				StartCoroutine(PlayAudio (timer));
				playTick = true;
			}
			else if (timer == 0) {
				ToolsStateManager.singleton.TransitionState(ToolsStateManager.singleton.DisableString);
				if (!playDing) {
					aud.PlayOneShot (ding);
					done = true;
					StopCoroutine ("endTime");
					playDing = true;
				}
				StartCoroutine ("complete");
			}
			else if (timer < 10) {
				countdown.text = ":0" + timer;
			}
			else {
				countdown.text = ":" + timer;
			}
		}

		//Countdown 3..2..1..
		IEnumerator count() {
			starttimer = 3;

			startcountdown.enabled = true;
			while (starttimer > 0) {
				startcountdown.text = starttimer.ToString();
				starttimer--;
				yield return new WaitForSeconds (1);
			}
			startcountdown.enabled = false;
			Debug.Log(ToolsStateManager.singleton.CurrentState.Name);
   			ToolsStateManager.singleton.TransitionState(ToolsStateManager.singleton.IdleString);
			StartCoroutine ("endTime");

		}
		public void startTime() {
			startcountdown.gameObject.SetActive (true);
			running = true;
			StartCoroutine ("count");
		}

		IEnumerator endTime() {
			//Countdown from timer variable
			while (true) {
				yield return new WaitForSeconds (1);
				timer--;
			}
		}

		IEnumerator PlayAudio (int times) {
			for(int i = 0; i < times; i++) {
				aud.PlayOneShot (ticker);
				yield return new WaitForSeconds(ticker.length);
			}
		}

		IEnumerator complete() {
			waiting.gameObject.SetActive (false);
			timesUp.gameObject.SetActive (true);
			yield return new WaitForSeconds (2);
			timesUp.gameObject.SetActive (false);

		}

		public void reset(bool drawing) {

			done = false;
			playTick = false;
			playDing = false;

			if (drawing) {
				timer = 30;
			}
			else {
				timer = 20;
			}
		}
	}
}
