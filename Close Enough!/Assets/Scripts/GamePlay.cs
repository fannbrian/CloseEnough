using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CloseEnough {
	public class GamePlay : MonoBehaviour {
		public static GamePlay instance;
		public int rounds = GameInformation.rounds;

		public Timer timer;
		public ScreenCapture screenCap;

		private bool drawing;

		// UI
		public ToolsSlide toolSlideOut;
		public DoneSlide doneSlideOut;
		public ToolsSlide toolSlideIn;
		public DoneSlide doneSlideIn;
		public RectTransform guessingPanel;
		public RawImage image;
		public Button next;
		public GameObject drawingAudio;
		public GameObject swipeManager;
		public InputField guessedInput;
		public string wordToDraw;
		public Text word;
		public RectTransform guessedWordPanel;
		public Text guessedWord;
		public Text roundText;

		private bool resetScene;
        
		void Start() {
			instance = this;
			drawing = true;
			resetScene = false;

			guessingPanel.gameObject.SetActive (false);
			next.gameObject.SetActive (false);         
		}

		void Update () {
			// If the game is in play
			if (rounds > 0) {
				// If a round is complete and timer just finished counting down
				// Ending stage
				if (timer.done && timer.running) {
					// Drawing round
					if (drawing) {
						doneDraw ();
					// Guessing round
					} else {
						doneGuess ();
						resetScene = true;
					}
					// reset timer
					drawing = !drawing;
					timer.reset(drawing);
					next.onClick.AddListener (() => continueGame());
					rounds--;
				// Starting to play and timer hasn't counted yet
				// Prepping stage
				} else if (!timer.done && !timer.running) {
					// Drawing Round
					if (drawing) {
//						prepDraw ();
//						Draw ();

						// Guessing Round
					} else {
						prepGuess ();
						Guess ();
					}	
				}
			}
		}

		// Loading screen before drawing round starts
		public void prepDraw() {
			
		}

		public void Draw() {
			// Set Text to the word passed by another player
			word.text = wordToDraw;

			// UI
			next.gameObject.SetActive (false);
			doneSlideIn.playIn = true;
			toolSlideIn.playIn = true;
			swipeManager.gameObject.SetActive (true);

			// Begin Drawing Round
			timer.startTime ();
			StartCoroutine ("DisplayDrawingWord");
		}

		// Display the Text passed by another player
		IEnumerator DisplayDrawingWord() {
			roundText.text = "Drawing Round";
			roundText.gameObject.SetActive (true);
			word.gameObject.SetActive (true);
			yield return new WaitForSeconds (3);
			roundText.gameObject.SetActive (false);
			word.gameObject.SetActive (false);
		}

		public void doneDraw() {
			// UI
			doneSlideOut.playOut = true;
			toolSlideOut.playOut = true;

			// Disable drawing
			swipeManager.gameObject.SetActive (false);

			StartCoroutine ("ScreenshotDrawing");
		}

		IEnumerator ScreenshotDrawing() {
			yield return new WaitForSeconds (2);
			if (!screenCap.shot) {
				screenCap.done ();
			}
			yield return new WaitForSeconds (1);

			// UI
			SwipeTrail.singleton.Clear ();
			screenCap.showImage ();
			next.gameObject.SetActive (true);

			// Drawing Round complete
			drawing = false;
		}

		// Loading screen before guessing round starts
		public void prepGuess() {
			
		}

		public void Guess() {
			//Set image to guess to the image passed by another player
			image.texture = screenCap.image.texture;

			//UI
			screenCap.imagePanel.gameObject.SetActive (false);
			next.gameObject.SetActive (false);
			doneSlideIn.playIn = true;

			// Begin Guessing Round
			timer.startTime ();
			StartCoroutine ("GuessRound");
		}

		IEnumerator GuessRound() {
			roundText.text = "Guessing Round";
			roundText.gameObject.SetActive (true);
			yield return new WaitForSeconds (3);
			roundText.gameObject.SetActive (false);
			guessingPanel.gameObject.SetActive (true);

		}

		public void doneGuess() {
			StartCoroutine ("DoneGuessingUI");
			drawing = true;
			wordToDraw = guessedInput.text;
		}

		IEnumerator DoneGuessingUI() {
			doneSlideOut.playOut = true;
			yield return new WaitForSeconds (2);
			guessingPanel.gameObject.SetActive (false);
			guessedWord.text = guessedInput.text;
			guessedWordPanel.gameObject.SetActive (true);
			next.gameObject.SetActive (true);
		}

		public void continueGame() {
			if (rounds <= 0) {
				Destroy(drawingAudio);
				SceneManager.LoadScene ("Lobby");
			} else {
				// After guessing round completes, reload Main scene to start drawing
				if (resetScene) {
					SceneManager.LoadScene ("Main");
					resetScene = false;
				} 
				// Reset timer to not counting down
				timer.running = false;
			}
		}
	}
}
