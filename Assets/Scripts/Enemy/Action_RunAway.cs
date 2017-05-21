using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Enemy_Evasion")]
public class Action_RunAway : Action
{
	[SerializeField] float safeDistance = 3f;
	[SerializeField] float timeToChangeDirection = 2f;

	float randomDirectionAngle = 0f;
	float timer = 0f;
	
	public override void Init(StateController controller) {
		Debug.Log("RUN AWAY STATE");
	}

	public override void Act(StateController controller) {
		runAway(controller as Enemy_StateController);
	}

	private void runAway(Enemy_StateController controller) {
		timer += Time.deltaTime;
		if(timer >= timeToChangeDirection) {
			timer = 0f;
			randomDirectionAngle = Random.Range(-45f, 45f);
		}

		controller.anim.SetBool("ChaseState", true);

		Vector3 destination = getEvasionPosition(controller);

		controller.navMeshAgent.SetDestination(destination);
		controller.navMeshAgent.isStopped = false;
	}

	private Vector3 getEvasionPosition(Enemy_StateController controller) {
		
		Vector3 targetToAvoidPosition = controller.chaseTarget.position;
		targetToAvoidPosition.y = 0;

		Vector3 runnerPosition = controller.transform.position;
		runnerPosition.y = 0;

		Vector3 directionToRunAway = (targetToAvoidPosition - runnerPosition).normalized;
		directionToRunAway = (directionToRunAway * -1) * safeDistance;
		directionToRunAway = Quaternion.AngleAxis( randomDirectionAngle, Vector3.up ) * directionToRunAway;

		Vector3 destination = runnerPosition + directionToRunAway;
		
		Debug.DrawLine(targetToAvoidPosition, runnerPosition, Color.yellow);
		Debug.DrawLine(runnerPosition, destination);

		return destination;
	}

	public override void Clear(StateController controller){
		var enemyControl = controller as Enemy_StateController;
        enemyControl.anim.SetBool("ChaseState", false);
	}
}
