using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Stop")]
public class Action_Stop : Action
{
	public override void Init(StateController controller) {
		return;
	}
	
	public override void Act(StateController controller) {		
		stop(controller as Enemy_StateController);
	}

	private void stop(Enemy_StateController controller) {
		controller.anim.SetBool("IdleState", true);
		controller.navMeshAgent.isStopped = true;
	}

	public override void Clear(StateController controller){
		return;
	}
}
