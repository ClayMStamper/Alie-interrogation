using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Laughter isn't implemented here since the smiley faces
// are just a proof of concept

public class NPCEmotions : MonoBehaviour {

	public const string JOY = "joy";
	public const string FEAR = "fear";
	public const string LAUGHTER = "laughter";
	public const string PAIN = "pain";

	GameObject currentFace;

	public Dictionary <string, float> emotions;

	// Use this for initialization
	void Start () {

//		ChangeFace (happy);

		emotions = new Dictionary<string, float> ();
		emotions.Add ("joy", 10);
		emotions.Add("fear", 10);
		emotions.Add("laughter", 10);
		emotions.Add("pain", 10);

	}

	public void AddFear(float fear){
		UpdateEmotions (FEAR, emotions [FEAR] += fear);
	}
	public void AddPain(float pain){
		UpdateEmotions (PAIN, emotions [PAIN] += pain);
	}
	public void AddJoy(float joy){
		UpdateEmotions (JOY, emotions [JOY] += joy);
	}
	public void AddLaughter(float laughter){
		UpdateEmotions (LAUGHTER, emotions [LAUGHTER] += laughter);
	}

	void UpdateEmotions(string key, float value){

		//clamps the new value between 0 and 100;
		emotions [key] = Mathf.Clamp (value, 0f, 100f);;

		OnUpdateEmotions ();

	}

	//emotion update callback:
	//where visible changes to the npc are made
	void OnUpdateEmotions(){

	//	Debug.Log ("joy = " + emotions [JOY]);
	//	Debug.Log ("Fear = " + emotions [FEAR]);
	//	Debug.Log ("Pain = " + emotions [PAIN]);

//		GameObject newFace = happy;

		//happy
		if (emotions [FEAR] < 50f && emotions [PAIN] < 50f) {
			if (emotions [JOY] > 20f) {
//				newFace = happy;
				if (emotions [JOY] > 50f) {
//					newFace = pleased;
					if (emotions [JOY] > 70f) {
//						newFace = lovey;
					}
				}
//				ChangeFace (newFace);
			} 
		}

		//scared
		if ((emotions [JOY] / emotions [FEAR]) < 2 && emotions [FEAR] > emotions[PAIN]) { 
			if (emotions [FEAR] > 10f) {
//				newFace = cringe;
				if (emotions [FEAR] > 30f) {
//					newFace = worried;
					if (emotions [FEAR] > 50f) {
//						newFace = scared;
						if (emotions [FEAR] > 70f) {
//							newFace = doomed;
						}
					}
				}
			}
//			ChangeFace (newFace);
		}

		//hurt
		if ((emotions [JOY] / emotions [PAIN]) < 2 && emotions [PAIN] > emotions [FEAR]) { 
			if (emotions [PAIN] > 10f) {
//				newFace = sad;
				if (emotions [PAIN] > 20f) {
//					newFace = gasp;
					if (emotions [PAIN] > 40f) {
//						newFace = offended;
						if (emotions [PAIN] > 60f) {
//							newFace = pissed;
							if (emotions [PAIN] > 80f) {
//								newFace = crying;
							}
						}
					}
				}
			}
//			ChangeFace (newFace);
		}


	}
		
	void ChangeFace(){
		

	}
}
