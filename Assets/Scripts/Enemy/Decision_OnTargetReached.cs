using UnityEngine;

[CreateAssetMenu (menuName = "AI/Decisions/TargetReached")]
public class Decision_OnTargetReached : Decision
{
	public float distanceToReach;
	
	public override bool Decide(StateController controller) {
		return isTargetReached(controller);
	}

	private bool isTargetReached(StateController controller) {
		var enemyControl = controller as Enemy_StateController;

		Vector3 enemyPos = enemyControl.gameObject.transform.position;
		Vector3 playerPos = enemyControl.chaseTarget.position;

		if (Vector3.Distance(enemyPos, playerPos) <= distanceToReach) {
			return true;
		} else {
			return false;
		}
	}
}
