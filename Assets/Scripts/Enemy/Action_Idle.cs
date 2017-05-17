using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Idle : Action {

	public override void Init(StateController controller) {
		return;
	}
	
	public override void Act(StateController controller) {		
		stayStill(controller as Enemy_StateController);
	}

	private void stayStill(Enemy_StateController controller) {
		controller.navMeshAgent.isStopped = true;
	}
}
