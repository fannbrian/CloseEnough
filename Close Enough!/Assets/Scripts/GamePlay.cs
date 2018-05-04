using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour {

	public Timer timer;

	private bool drawing;

	public ToolsSlide toolSlideOut;
	public DoneSlide doneSlideOut;
//	public ToolsSlide toolSlideIn;
	public DoneSlide doneSlideIn;

	public ScreenCapture screenCap;
	private bool snap;

	public Button next;
	 
	public RectTransform guessingPanel;
	public RawImage image;
	 
	void Start() {
		snap = false;
		drawing = true;

		guessingPanel.gameObject.SetActive (false);
		next.gameObject.SetActive (false);

		timer.startTime ();
	}

	void Update () {
		// Done playing
		if (timer.done && timer.playing) {
			if (drawing) {
				toolSlideOut.play = true;
				doneSlideOut.playOut = true;
				if (!snap) {
					StartCoroutine ("screenshot");
				}
			}
			// reset timer
//			timer.done = false;
//			timer.timer = 30;
			timer.reset();
		// Starting to play
		} else if (!timer.done && !timer.playing) {
			if (!drawing) {
				image.texture = screenCap.texture;
				screenCap.imagePanel.gameObject.SetActive (false);
				snap = false;
				next.gameObject.SetActive (false);

				doneSlideIn.playIn = true;
				StartCoroutine ("startGuessing");
				timer.startTime ();

			}
		}
	}

	IEnumerator screenshot() {
		yield return new WaitForSeconds (2);

		screenCap.done ();
		yield return new WaitForSeconds (1);

		screenCap.showImage ();
		next.gameObject.SetActive (true);

		snap = true;
		drawing = false;

	}

	IEnumerator startGuessing() {
		yield return new WaitForSeconds (3);
		guessingPanel.gameObject.SetActive (true);

	}
}
