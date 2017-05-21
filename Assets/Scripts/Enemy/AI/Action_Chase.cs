using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Chase")]
public class Action_Chase : Action
{
	public override void Init(StateController controller) {
		Debug.Log("CHASE STATE");
	}

	public override void Act(StateController controller) {
		chase(controller as Enemy_StateController);
	}

	private void chase(Enemy_StateController controller) {
        controller.anim.SetBool("ChaseState", true);

		controller.navMeshAgent.isStopped = false;
		controller.navMeshAgent.destination = controller.chaseTarget.position;
	}

	public override void Clear(StateController controller){
		var enemyControl = controller as Enemy_StateController;

        enemyControl.anim.SetBool("ChaseState", false);
	}
}