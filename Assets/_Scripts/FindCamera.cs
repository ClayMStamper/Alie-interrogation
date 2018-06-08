using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCamera : MonoBehaviour {

	private Canvas canvas;

	void Start(){
		canvas = GetComponent <Canvas> ();
	}

	void Update(){

		if (canvas.worldCamera == Camera.main)
			return;

		canvas.worldCamera = Camera.main;

	}
}
