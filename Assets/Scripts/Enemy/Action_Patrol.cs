using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Enemy_Patrol")]
public class Action_Patrol : Action
{
    public override void Init(StateController controller) {
        Debug.Log("PATROL STATE");
    }

	public override void Act(StateController controller)
	{
		Act(controller as Enemy_StateController);
    }

	public void Act(Enemy_StateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(Enemy_StateController controller)
    {
        controller.anim.SetBool("PatrolState", true);
        controller.navMeshAgent.destination = controller.movementVariables.wayPointList [controller.movementVariables.nextWayPoint].position;
        controller.navMeshAgent.isStopped = false;

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending) 
        {
            controller.movementVariables.nextWayPoint = (controller.movementVariables.nextWayPoint + 1) % controller.movementVariables.wayPointList.Count;
        }
    }

    public override void Clear(StateController controller){
		var enemyControl = controller as Enemy_StateController;
        enemyControl.anim.SetBool("PatrolState", false);
	}
}