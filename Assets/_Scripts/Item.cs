using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))][RequireComponent(typeof(Rigidbody))]
public abstract class Item : MonoBehaviour {

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

	void OnCollisionEnter(Collision col){

		NPC = col.gameObject.GetComponent<NPCEmotions> ();

		strength = Mathf.Abs(Mathf.Max (rb.velocity.x, rb.velocity.y));

		audio.volume = (strength / 50);

		//hits a player
		if (NPC != null && justHit == false) {

			audio.clip = soundEffects [0];
			audio.Play ();

			AffectNPC (NPC);
			justHit = true;

		} else if (col.transform.tag == "Surface" && justHit == false) { //hit something else
			
			audio.clip = soundEffects [1];
			audio.Play ();
			justHit = true;

		}

	}

	//keeps from repeatedly hitting
	void OnCollisionExit(Collision col){

		NPC = col.gameObject.GetComponent<NPCEmotions> ();

		justHit = false;

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

}
