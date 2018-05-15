using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough {
	
	public class DoneButtonPressed : MonoBehaviour {
		public void clicked() {         
			RoundManager.instance.EndRound();
		}
	}

}