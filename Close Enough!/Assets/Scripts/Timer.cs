﻿using System;
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

		public bool playing = false;
		public bool done = false;

		public AudioClip ticker;
		public AudioClip ding;

		AudioSource aud;
		Boolean playTick;
		Boolean playDing;

		// Use this for initialization
		void Start () {
			playTick = false;
			playDing = false;
			timesUp.gameObject.SetActive (false);
			waiting.gameObject.SetActive (false);
			aud = GetComponent<AudioSource> ();
		}

		// Update is called once per frame
		void Update () {
			if (timer == 4 && !playTick) {
				aud.PlayOneShot (ticker, 1);
				playTick = true;
			}
			else if (timer < 0) {
				if (!playDing) {
					aud.PlayOneShot (ding, 1);
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

		IEnumerator count() {
			startcountdown.enabled = true;
			while (starttimer >= 0) {
				startcountdown.text = starttimer.ToString ();
				starttimer--;
				yield return new WaitForSeconds (1);

			}
			startcountdown.enabled = false;
		}

		public void startTime() {
			playing = true;
			StartCoroutine ("count");
			StartCoroutine ("endTime");
		}

		IEnumerator endTime() {
			//Countdown 3..2..1..
			yield return new WaitForSeconds (3);
			//Countdown from timer variable
			while (true) {
				yield return new WaitForSeconds (1);
				timer--;
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

			waiting.gameObject.SetActive (false);

			starttimer = 3;
			startcountdown.text = starttimer.ToString ();
			if (drawing) {
				timer = 30;
			}
			else {
				timer = 20;
			}
		}
	}
}
