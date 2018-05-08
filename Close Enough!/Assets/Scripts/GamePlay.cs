using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CloseEnough {

	public class GamePlay : MonoBehaviour {
// 		For testing purposes, change round to amount of turns you'd like to play
		static public int rounds = GameInformation.rounds;

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

		public InputField guessedInput;
		static public string wordToDraw;
		public Text word;

		public RectTransform guessedWordPanel;
		public Text guessedWord;

		private bool reset;

		static public bool ready;

		void Start() {
			snap = false;
			drawing = true;
			reset = false;

			guessingPanel.gameObject.SetActive (false);
			next.gameObject.SetActive (false);

			ready = true;
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
							StartCoroutine ("doneDraw");
							swipeManager.gameObject.SetActive (false);
						}
					// During a guessing round
					} else {
						StartCoroutine ("doneGuess");
						reset = true;
					}
					// reset timer
					drawing = !drawing;
					timer.reset(drawing);
					next.onClick.AddListener (() => continueGame());
					rounds--;
					// Starting to play
				} else if (!timer.done && !timer.playing) {
					// If round is to ready to play, prep and start
					if (ready) {
						// Drawing Round
						if (drawing) {
							prepDraw ();
							next.gameObject.SetActive (false);
							doneSlideIn.playIn = true;
							toolSlideIn.playIn = true;
							swipeManager.gameObject.SetActive (true);
							StartCoroutine ("Draw");

							// Guessing Round
						} else {
							prepGuess ();
							screenCap.imagePanel.gameObject.SetActive (false);
							snap = false;
							next.gameObject.SetActive (false);
							doneSlideIn.playIn = true;
							StartCoroutine ("Guess");
						}	
					}
				}
			}
		}

		private void prepDraw() {
			word.text = wordToDraw;
		}

		IEnumerator Draw() {
			timer.startTime ();
			word.gameObject.SetActive (true);
			yield return new WaitForSeconds (3);
			word.gameObject.SetActive (false);

		}

		IEnumerator doneDraw() {
			yield return new WaitForSeconds (2);
			screenCap.done ();
			yield return new WaitForSeconds (1);
			SwipeTrail.singleton.Clear ();
			screenCap.showImage ();

			snap = true;
			drawing = false;

			next.gameObject.SetActive (true);

		}

		private void prepGuess() {
			image.texture = screenCap.image.texture;
		}

		IEnumerator Guess() {
			timer.startTime ();
			yield return new WaitForSeconds (3);
			guessingPanel.gameObject.SetActive (true);
		}

		IEnumerator doneGuess() {
			doneSlideOut.playOut = true;
			yield return new WaitForSeconds (2);
			guessingPanel.gameObject.SetActive (false);
			drawing = true;
			wordToDraw = guessedInput.text;

			guessedWord.text = guessedInput.text;
			guessedWordPanel.gameObject.SetActive (true);
			print (guessedWordPanel.gameObject.GetActive ());
			next.gameObject.SetActive (true);


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
