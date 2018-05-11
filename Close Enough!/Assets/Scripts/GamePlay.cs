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
        
		public bool isDrawing;

		// UI
		public ToolsSlide toolSlide;
		public DoneSlide doneSlide;

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

		void Awake() {
			instance = this;
			isDrawing = true;

			next.gameObject.SetActive (false);
		}
              
		// Loading screen before drawing round starts
		public void prepDraw() {
			
		}

		public void Draw() {
			// Set Text to the word passed by another player
			word.text = "Your word is: \n"+wordToDraw;

			// UI
			next.gameObject.SetActive (false);
			doneSlide.PlayAnimation(true);
			toolSlide.PlayAnimation(true);
			swipeManager.gameObject.SetActive (true);
			isDrawing = true;

			// Begin Drawing Round
			timer.reset(isDrawing);
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
			Debug.Log("Done Draw");
			// UI         
			doneSlide.PlayAnimation(false);
			toolSlide.PlayAnimation(false);

            // Disable drawing
			ToolsStateManager.singleton.TransitionState(ToolsStateManager.singleton.DisableString);
			Screenshot();
			Invoke("DrawWaiting", .5f);
		}

		public void TimerDone() {
			if (isDrawing) {
				doneDraw();
			}
			else {
				doneGuess();
			}
		}

		void Screenshot() {
			screenCap.Screenshot();
		}

		void DrawWaiting() {
			var texBytes = screenCap.texture.EncodeToJPG();

            // UI
            SwipeTrail.singleton.Clear();
            //screenCap.showImage();
            next.gameObject.SetActive(true);

            // Drawing Round complete
            isDrawing = false;
                     
			var node = new StackNode(PhotonNetwork.player.ID, texBytes);
			var nodeBytes = ByteSerializer<StackNode>.Serialize(node);

			PanelReference.singleton.WaitingPanel.SetActive(true);
            var currentIndex = (GameData.CurrentRound + GameData.InitialIndex) % GameData.PlayerCount;
			GameData.LocalView.RPC("SendNode", PhotonTargets.All, currentIndex, nodeBytes);
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
			doneSlide.PlayAnimation(true);
			isDrawing = false;

			// Begin Guessing Round
			timer.reset(isDrawing);
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
			isDrawing = true;
			wordToDraw = guessedInput.text;
		}

		IEnumerator DoneGuessingUI() {
			doneSlide.PlayAnimation(false);
			yield return new WaitForSeconds (2);
			guessingPanel.gameObject.SetActive (false);
			guessedWord.text = guessedInput.text;
			guessedWordPanel.gameObject.SetActive (true);
			next.gameObject.SetActive (true);
		}

	}
}
