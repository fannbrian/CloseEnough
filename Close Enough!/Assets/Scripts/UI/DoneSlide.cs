using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneSlide : MonoBehaviour {

	Animator anim;

	public bool playIn;
	public bool playOut;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		playIn = false;
		playOut = false;      
	}

	public void PlayAnimation(bool isIn) {
		if (isIn) {
			anim.Play("DoneSlideIn");
		}
		else {
			anim.Play("DoneSlideOut");
		}
	}
}
