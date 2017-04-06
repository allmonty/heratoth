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
        controller.navMeshAgent.destination = controller.wayPointList [controller.nextWayPoint].position;
        controller.navMeshAgent.Resume ();

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending) 
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
    }
}