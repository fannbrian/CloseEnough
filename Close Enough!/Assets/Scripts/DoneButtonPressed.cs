using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough {

	/// <summary>
	/// End a round once the done button has been pressed.
	/// </summary>
	public class DoneButtonPressed : MonoBehaviour {
		public void clicked() {         
			RoundManager.instance.EndRound();
		}
	}

}