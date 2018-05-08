using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsSlide : MonoBehaviour {

	Animator anim;

	public bool playOut;
	public bool playIn;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		playOut = false;
		playIn = false;
	}

	// Update is called once per frame
	void Update () {
		if (playOut) {
			anim.Play ("ToolSlideOut");
			playOut = false;
		} else if (playIn) {
			anim.Play ("ToolSlideIn");
			playIn = false;
		}
	}

}