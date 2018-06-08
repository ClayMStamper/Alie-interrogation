using System.Collections;
using System.Collections.Generic;
using Oculus;
using UnityEngine;

public class SnapToChair : MonoBehaviour {

	[SerializeField]
	private Transform chair;

	[SerializeField]
	private Vector3 offset;

	void Start(){
		SnapToChairPos ();
	}

	void Update(){

		if (Input.GetButtonDown ("Fire1")) {
			print("Fire1");
			SnapToChairPos ();
		}
		if (Input.GetButtonDown ("Fire2")) {
			print("Fire2");
			SnapToChairPos ();
		}
		if (Input.GetButtonDown ("Fire3")) {
			Debug.Log("Fire3");
			SnapToChairPos ();
		}

	}

	void SnapToChairPos(){
		
		Vector3 newPos = chair.position;
		newPos += offset;

		transform.position = newPos;

	}

}
