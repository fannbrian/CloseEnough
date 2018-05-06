using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CloseEnough {

	public class GamePlay : MonoBehaviour {
// 		For testing purposes, change round to amount of turns you'd like to play
		static public int rounds = 4;
//		static public int rounds = GameInformation.rounds;

		public Timer timer;

		private bool drawing;

		public ToolsSlide toolSlideOut;
		public DoneSlide doneSlideOut;
		public ToolsSlide toolSlideIn;
		public DoneSlide doneSlideIn;

		public ScreenCapture screenCap;
		private bool snap;

		public Button next;
		public GameObject drawingAudio;

		public RectTransform guessingPanel;
		public RawImage image;

		public GameObject swipeManager;

		public InputField wordGuessed;
		static public string wordToDraw;
		public Text word;

		private bool reset;


		void Start() {
			snap = false;
			drawing = true;
			reset = false;

			guessingPanel.gameObject.SetActive (false);
			next.gameObject.SetActive (false);

		}

		void Update () {
			// If the game is in play
			if (rounds > 0) {
				// If a round is complete
				if (timer.done && timer.playing) {
					// During a drawing round
					if (drawing) {
						// 
						toolSlideOut.playOut = true;
						doneSlideOut.playOut = true;
						if (!snap) {
							StartCoroutine ("doneDrawing");
							swipeManager.gameObject.SetActive (false);

						}
					// During a guessing round
					} else {
						StartCoroutine ("doneGuessing");
						reset = true;
					}
					// reset timer
					drawing = !drawing;
					timer.reset(drawing);
					next.onClick.AddListener (() => continueGame());
					rounds--;
					// Starting to play
				} else if (!timer.done && !timer.playing) {
					// Drawing round
					if (drawing) {
						next.gameObject.SetActive (false);
						doneSlideIn.playIn = true;
						toolSlideIn.playIn = true;
						swipeManager.gameObject.SetActive (true);
						StartCoroutine ("startDrawing");

					// Guessing round
					} else {
						image.texture = screenCap.image.texture;
						screenCap.imagePanel.gameObject.SetActive (false);
						snap = false;
						next.gameObject.SetActive (false);
						doneSlideIn.playIn = true;
						StartCoroutine ("startGuessing");
					}
					timer.startTime ();


				}
			}

		}

		IEnumerator startDrawing() {
			yield return new WaitForSeconds (3);
			word.enabled = false;

		}

		IEnumerator doneDrawing() {
			yield return new WaitForSeconds (2);
			screenCap.done ();
			yield return new WaitForSeconds (1);

			screenCap.showImage ();

			snap = true;
			drawing = false;

			next.gameObject.SetActive (true);

		}


		IEnumerator startGuessing() {
			yield return new WaitForSeconds (3);
			guessingPanel.gameObject.SetActive (true);
		}

		IEnumerator doneGuessing() {
			doneSlideOut.playOut = true;
			yield return new WaitForSeconds (2);
			next.gameObject.SetActive (true);
			guessingPanel.gameObject.SetActive (false);
			drawing = true;
			wordToDraw = wordGuessed.text;

		}

		public void continueGame() {
			if (rounds <= 0) {
				Destroy(drawingAudio);
				SceneManager.LoadScene ("Lobby");
			} else {
				if (reset) {
					SceneManager.LoadScene ("Main");
					reset = false;
				} else {
					timer.playing = false;

				}
			}
		}
	}
}
