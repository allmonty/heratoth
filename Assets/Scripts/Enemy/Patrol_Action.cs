using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Enemy_Patrol")]
public class Patrol_Action : Action
{
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
        controller.navMeshAgent.destination = controller.movementVariables.wayPointList [controller.movementVariables.nextWayPoint].position;
        controller.navMeshAgent.Resume ();

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending) 
        {
            controller.movementVariables.nextWayPoint = (controller.movementVariables.nextWayPoint + 1) % controller.movementVariables.wayPointList.Count;
        }
    }
}