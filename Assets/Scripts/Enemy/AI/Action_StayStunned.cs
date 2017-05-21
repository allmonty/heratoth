using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/StayStunned")]
public class Action_StayStunned : Action
{
	public override void Init(StateController controller) {
		Debug.Log("STAY STUNNED STATE");
	}
	
	public override void Act(StateController controller) {		
		stayStill(controller as Enemy_StateController);
	}

	private void stayStill(Enemy_StateController controller) {
		controller.anim.SetBool("ReactState", true);

		controller.navMeshAgent.isStopped = true;
	}

	public override void Clear(StateController controller){
		var enemyControl = controller as Enemy_StateController;
		
		enemyControl.anim.SetBool("ReactState", false);
	}
}
