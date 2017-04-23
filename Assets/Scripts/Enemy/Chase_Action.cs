using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Chase")]
public class Chase_Action : Action {

	public override void Act(StateController controller) {
		chase(controller);
	}

	private void chase(StateController controller) {
		var enemyControl = controller as Enemy_StateController;

		enemyControl.navMeshAgent.destination = enemyControl.chaseTarget.position;
		enemyControl.navMeshAgent.isStopped = false;
	}
}
