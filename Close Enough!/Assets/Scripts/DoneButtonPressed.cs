using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoneButtonPressed : MonoBehaviour {

	// User clicks after completing their drawing/guess
	public Text waiting;

	public void clicked() {
		waiting.enabled = true;
	}
}
