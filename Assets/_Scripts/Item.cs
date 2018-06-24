using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))][RequireComponent(typeof(Rigidbody))]
public abstract class Item : MonoBehaviour {

	//The last item that was grabbed
	public static Item lastGrabbed;

	//factored into stat modifications instead of changing stat mods
	protected float strength = 1.0f;

	public float joyMod = 1;
	public float laughterMod = 1;
	public float fearMod = 1;
	public float painMod = 1;

	protected Rigidbody rb;
	protected new AudioSource audio;

	NPCEmotions NPC;

	bool justHit = false;

	[HideInInspector]
	public bool hitting = false;
	Vector3 hitDirection;

	public AudioClip[] soundEffects;

	void Awake(){

		//reference rigidbody and audiosource

		if (GetComponent <Rigidbody> () == null) {
			rb = gameObject.AddComponent<Rigidbody> ();
		} else {
			rb = GetComponent <Rigidbody> ();
		}

		if (GetComponent <AudioSource> () == null) {
			audio = gameObject.AddComponent<AudioSource> ();
		} else {
			audio = GetComponent <AudioSource> ();
		}

	}

	void Update(){

		if (hitting) {

			Vector3 clampedPos = transform.position;

			if (hitDirection.x > 0) {
				clampedPos.x = Mathf.Clamp (clampedPos.x, float.MinValue, clampedPos.x);
			} else if (hitDirection.x < 0){
				clampedPos.x = Mathf.Clamp (clampedPos.x, clampedPos.x, float.MaxValue);
			}

		}

	}

	void OnCollisionEnter(Collision col){

		NoPassThrough (col.transform);

		if (justHit)
			return;

		NPC = col.gameObject.GetComponent<NPCEmotions> ();

		strength = Mathf.Abs(Mathf.Max (rb.velocity.x, rb.velocity.y));

		audio.volume = (strength / 50);

		Debug.Log ("Just hit: " + justHit);

		//hits a player
		if (NPC != null) {

			justHit = true;
			StartCoroutine (JustHit ());

			audio.clip = soundEffects [0];
			audio.Play ();

			AffectNPC (NPC);

		} else if (col.transform.tag == "Surface") { //hit something else

			justHit = true;
			StartCoroutine (JustHit ());

			audio.clip = soundEffects [1];
			audio.Play ();

		}

	}

	void OnCollisionExit(Collision col){
		hitting = false;
	}

	public virtual void Cast(){

		//something that would be used to detect things like pointing a flash light,
		//threatening with a knife, or offering a donut using raycasts (ray tracing)
		//even things like feathers can use short range ray casts

	}

	//meant to be overwritten by specific item and still lacks 
	//levels of abstraction. Might need to be redesigned to accomodate
	//items that Cast() can't
	public virtual void AffectNPC(NPCEmotions NPC){

		NPC.AddPain (strength * painMod);
		NPC.AddFear (strength * fearMod);
		NPC.AddJoy (strength * joyMod);
		NPC.AddLaughter (strength * laughterMod);

	}

	IEnumerator JustHit(){

		while (true) {

			Debug.Log ("waiting");

			yield return new WaitForSeconds (1f);

			justHit = false;
			Debug.Log ("can hit again");

		}

	}

	void NoPassThrough(Transform col){

		hitting = true;

		Vector3 heading = col.position - transform.position;

		float distance = heading.magnitude;
		hitDirection = heading / distance;

//		Debug.Log (hitDirection);

	}

}
