using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough {
	
	public class DoneButtonPressed : MonoBehaviour {

		// User clicks after completing their drawing/guess
		public Text waiting;

		public void clicked() {
			waiting.gameObject.SetActive (true);
			waiting.enabled = true;
			ToolsStateManager.singleton.TransitionState(ToolsStateManager.singleton.DisableString);

			// Signal that user is complete with the round

		}
	}

}