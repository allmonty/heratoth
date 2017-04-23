using UnityEngine;

[CreateAssetMenu (menuName = "AI/Decisions/TargetReached")]
public class Decision_OnTargetReached : Decision {

	public bool overrideDistanceToReach;
	public float distanceToReach;
	
	public override bool Decide(StateController controller) {
		return isTargetReached(controller);
	}

	private bool isTargetReached(StateController controller) {
		var enemyControl = controller as Enemy_StateController;
		
		enemyControl.navMeshAgent.destination = enemyControl.chaseTarget.position;		

		if(!overrideDistanceToReach)
			distanceToReach = enemyControl.navMeshAgent.stoppingDistance;

		if(enemyControl.navMeshAgent.remainingDistance <= distanceToReach && !enemyControl.navMeshAgent.pathPending) {
			enemyControl.navMeshAgent.Stop();
			return true;
		} else {
			enemyControl.navMeshAgent.Resume();
			return false;
		}
	}
}
