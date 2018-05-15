using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace CloseEnough
{
	public class GuessingPanelReferences : MonoBehaviour
	{
		public static GuessingPanelReferences instance;

        void Awake()
        {
            instance = this;
        }

		public GameObject GuessingPanel;
		public Text Guess;
		public RawImage Drawing;
		public ScreenCapture Capture;
		public Text RoundText;
	}
}