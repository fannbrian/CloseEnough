using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsSlide : MonoBehaviour {

	Animator anim;

	public bool playOut;
	public bool playIn;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		playOut = false;
		playIn = false;
	}

    public void PlayAnimation(bool isIn)
    {
        if (isIn)
        {
            anim.Play("ToolSlideIn");
        }
        else
        {
            anim.Play("ToolSlideOut");
        }
    }   
}