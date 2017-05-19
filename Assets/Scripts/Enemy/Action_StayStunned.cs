using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/StayStunned")]
public class Action_StayStunned : Action {

	public override void Init(StateController controller) {
		Debug.Log("SSTAY STUNNED STATE");
	}
	
	public override void Act(StateController controller) {		
		stayStill(controller as Enemy_StateController);
	}

	private void stayStill(Enemy_StateController controller) {
		controller.GetComponentInChildren<Animator>().SetBool("ReactState", true);
		controller.navMeshAgent.isStopped = true;
		controller.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	public override void Clear(StateController controller){
		controller.GetComponentInChildren<Animator>().SetBool("ReactState", false);
	}
}
