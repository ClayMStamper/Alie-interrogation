using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingGlove : Item {

	Animator anim;

	void Start(){
		anim = GetComponent <Animator> ();
	}

	void Update(){

		float dir = Input.GetAxis ("Mouse ScrollWheel");

		if (dir > 0f) {
			anim.SetFloat ("Blend", Mathf.Clamp (anim.GetFloat ("Blend") + 0.1f, 0, 1));
		} else if (dir < 0f) {
			anim.SetFloat ("Blend", Mathf.Clamp (anim.GetFloat ("Blend") - 0.1f, 0, 1));
		}

	}

}
