using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonVRPlayerGrab : MonoBehaviour {

	Vector3 offset;
	Rigidbody rb;

	//where items go when they're not picked up
	public Transform defaultParent;

	//the item currently in the players hand
	Transform item;

	void Update(){

		if (Input.GetMouseButtonDown (0)) {

			if (item == null) {

				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));

				if (Physics.Raycast (ray, out hit, 100.0f)) {

					//obj clicked on is an item
					if (hit.transform.GetComponent<Item> ()) {
						
						item = hit.transform;

						rb = item.GetComponent <Rigidbody> ();
						rb.angularDrag = 100f;
						item.SetParent (Camera.main.transform);
						offset = item.localPosition;
						item.localRotation = Quaternion.Euler (Vector3.zero);
					}

				}
			} else { //clicked to drop item
				
				rb.angularDrag = 0.15f;
			//	rb.AddForce (rb.angularVelocity);
				item.SetParent (defaultParent);

				item = null;

			}

		}

		//scroll in and out to bring items closer
		float dir = Input.GetAxis ("Mouse ScrollWheel");

		if (dir > 0f) {
		//	offset.z += 0.1f;
		} else if (dir < 0f) {
		//	offset.z -= 0.1f;
		}
			
		if (item != null) {

			item.localPosition = offset;
	//		item.localRotation = Quaternion.Euler (Vector3.zero);

		}

	}
}
