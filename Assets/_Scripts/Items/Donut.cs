using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : Item {

	[SerializeField]
	Mesh[] meshes;

	int bites = 0;

	MeshFilter meshFilter;
	MeshCollider col;

	void Start(){

		meshFilter = GetComponent <MeshFilter> ();
		col = GetComponent <MeshCollider> ();

	}

	public override void AffectNPC (NPCEmotions NPC)
	{
		bites++;

		NPC.AddPain (painMod);
		NPC.AddFear (fearMod);
		NPC.AddJoy (joyMod);
		NPC.AddLaughter (laughterMod);

		if (bites >= 2) {
			Destroy (gameObject);
		}

		meshFilter.mesh = meshes [bites];
		col.sharedMesh = meshFilter.mesh;

	}

}
