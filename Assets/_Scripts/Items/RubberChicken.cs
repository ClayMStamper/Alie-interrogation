using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberChicken : Item {

	public override void AffectNPC (NPCEmotions NPC) {
		Debug.Log (strength);
		NPC.AddPain (-strength / 5);
		NPC.AddFear (-strength / 20);
	//	NPC.AddJoy (-strength / 5);
		NPC.AddLaughter (strength * 2);
	}
}
