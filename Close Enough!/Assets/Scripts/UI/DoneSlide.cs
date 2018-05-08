using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneSlide : MonoBehaviour {

	Animator anim;

	public bool playIn;
	public bool playOut;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		playIn = false;
		playOut = false;

	}

	// Update is called once per frame
	void Update () {
		if (playIn) {
			anim.Play ("DoneSlideIn");
			playIn = false;
		} else if (playOut) {
			anim.Play ("DoneSlideOut");
			playOut = false;
		}
	}

}
