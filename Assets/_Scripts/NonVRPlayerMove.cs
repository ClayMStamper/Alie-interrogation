using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonVRPlayerMove : MonoBehaviour {

	public float speed;

	public float mouseSensitivity = 100.0f;
	public float clampAngle = 80.0f;

	private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the right/x axis

	void Start ()
	{

		//gets rid of cursor
		Cursor.lockState = CursorLockMode.Locked;

		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
	}


	void Update () {

		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = -Input.GetAxis("Mouse Y");

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		transform.rotation = localRotation;

		//move forward
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		//move left
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
		//move right
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right* speed * Time.deltaTime);
		}
		//move back
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.back * speed * Time.deltaTime);
		}
		//move forward
		if (Input.GetKey (KeyCode.Space)) {
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		}

	}
}
