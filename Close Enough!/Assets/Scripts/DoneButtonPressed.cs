using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoneButtonPressed : MonoBehaviour {

	public Text waiting;

	public void clicked() {
		waiting.enabled = true;
	}
}
