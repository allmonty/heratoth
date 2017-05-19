using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Chase")]
public class Action_Chase : Action {

	public override void Init(StateController controller) {
		Debug.Log("CHASE STATE");
		var control = controller as Enemy_StateController;
	}

	public override void Act(StateController controller) {
		chase(controller);
	}

	private void chase(StateController controller) {
		var enemyControl = controller as Enemy_StateController;
        enemyControl.anim.SetBool("ChaseState", true);

		enemyControl.navMeshAgent.isStopped = false;
		enemyControl.navMeshAgent.destination = enemyControl.chaseTarget.position;
	}

	public override void Clear(StateController controller){
		var enemyControl = controller as Enemy_StateController;
        enemyControl.anim.SetBool("ChaseState", false);
	}
}