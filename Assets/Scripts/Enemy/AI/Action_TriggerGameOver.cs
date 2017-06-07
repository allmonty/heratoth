using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu (menuName = "AI/Actions/TriggerGameOver")]
public class Action_TriggerGameOver : Action
{
	public override void Init(StateController controller) {
		GameManager.instance.gameOver();
	}

	public override void Act(StateController controller)
	{
		return;
	}
	
	public override void Clear(StateController controller){
		return;
	}
}