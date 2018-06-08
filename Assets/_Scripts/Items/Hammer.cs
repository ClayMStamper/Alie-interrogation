using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Item {

	public override void AffectNPC (NPCEmotions NPC) {

		Debug.Log (strength);
		NPC.AddPain (strength);
		NPC.AddFear (strength / 2);
		NPC.AddJoy (-strength / 2);
		NPC.AddLaughter (-strength / 2);
	}

}
