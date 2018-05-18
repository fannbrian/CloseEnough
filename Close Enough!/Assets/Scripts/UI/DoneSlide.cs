using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Animation for the right bar.
/// </summary>
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

	private void Update()
	{
		if (playIn) {
			anim.Play("DoneSlideIn");
			playIn = false;
		}
		if (playOut) {
			anim.Play("DoneSlideOut");
			playOut = false;
		}
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
