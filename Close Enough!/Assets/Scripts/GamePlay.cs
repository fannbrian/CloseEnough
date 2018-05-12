using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CloseEnough {
	public class GamePlay : MonoBehaviour {
		public static GamePlay instance;
		public int rounds = 1;

		public Timer timer;
		public ScreenCapture screenCap;
        
		public bool isDrawing;

		// UI
		public ToolsSlide toolSlide;
		public DoneSlide doneSlide;

		public RectTransform guessingPanel;
		public RawImage image;
		public GameObject drawingAudio;
		public GameObject swipeManager;
		public InputField guessedInput;
		public string wordToDraw;
		public Text word;
		public Text roundText;

		bool _isRoundDone;

		public bool IsRoundDone() {
			return _isRoundDone;
		}

		void Awake() {
			instance = this;
			isDrawing = true;
            
			rounds = PhotonNetwork.playerList.Length;
		}
              
		// Loading screen before drawing round starts
		public void prepDraw() {
			
		}

		public void Draw() {
			_isRoundDone = false;
			// Set Text to the word passed by another player
			if (wordToDraw == "") {
				word.text = "...they didn't guess.\nFeel free to draw anything.";
			}
			else {
                word.text = "Your word is: \n" + wordToDraw;
			}

			// UI
			doneSlide.PlayAnimation(true);
			toolSlide.PlayAnimation(true);
			swipeManager.gameObject.SetActive (true);
			isDrawing = true;

			// Begin Drawing Round
			timer.ResetTimer(isDrawing);
			timer.StartTimer();
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
			Invoke("Screenshot", .5f);
			Invoke("DrawWaiting", .8f);
		}

		public void FinishRound() {
			if (_isRoundDone) return;
			_isRoundDone = true;

			PanelReference.singleton.WarningPanel.SetActive(false);

			if (isDrawing) {
				ToolsStateManager.singleton.Enable(false);
			}

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

            // Drawing Round complete
            isDrawing = false;
                     
			var node = new StackNode(PhotonNetwork.player.ID, texBytes);
			var nodeBytes = ByteSerializer<StackNode>.Serialize(node);

			PanelReference.singleton.WaitingPanel.SetActive(true);
            var currentIndex = (GameData.instance.CurrentRound + GameData.instance.InitialIndex) % GameData.instance.PlayerCount;
			GameData.instance.LocalView.RPC("SendNode", PhotonTargets.All, currentIndex, nodeBytes);
		}

		// Loading screen before guessing round starts
		public void prepGuess() {
		}

		public void Guess() {
			_isRoundDone = false;

			//Set image to guess to the image passed by another player
			image.texture = screenCap.image.texture;

			//UI
			screenCap.imagePanel.gameObject.SetActive (false);
			isDrawing = false;

			// Begin Guessing Round
			timer.ResetTimer(isDrawing);
			timer.StartTimer();

            roundText.text = "Guessing Round";
			roundText.gameObject.SetActive(true);
			Invoke("DisableGuessRound", 3);
		}

		void DisableGuessRound() {
			roundText.gameObject.SetActive (false);
			guessingPanel.gameObject.SetActive (true);         
		}

		public void doneGuess() {         
			StartCoroutine ("DoneGuessingUI");
			wordToDraw = guessedInput.text;

            var node = new StackNode(PhotonNetwork.player.ID, wordToDraw);
            var nodeBytes = ByteSerializer<StackNode>.Serialize(node);

            PanelReference.singleton.WaitingPanel.SetActive(true);
            var currentIndex = (GameData.instance.CurrentRound + GameData.instance.InitialIndex) % GameData.instance.PlayerCount;
            GameData.instance.LocalView.RPC("SendNode", PhotonTargets.All, currentIndex, nodeBytes);
		}

		IEnumerator DoneGuessingUI() {
			doneSlide.PlayAnimation(false);
			yield return new WaitForSeconds (2);
			guessingPanel.gameObject.SetActive (false);
		}
	}
}
