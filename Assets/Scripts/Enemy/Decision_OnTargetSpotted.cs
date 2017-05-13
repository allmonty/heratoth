using UnityEngine;

[CreateAssetMenu (menuName = "AI/Decisions/TargetSpot")]
public class Decision_OnTargetSpotted : Decision {
	
	[SerializeField] float lookRange = 5f;
	[SerializeField] float lookMaxAngle = 20f;
	[SerializeField] string targetTag = "Player";

	[SerializeField] Transform target = null;

	public override bool Decide(StateController controller) {
		return TargetInSight(controller);
	}

	private bool TargetInSight(StateController controller) {
		Enemy_StateController control = controller as Enemy_StateController;
		Transform spotter = control.gameObject.transform;
		
		setTarget(control);

		debugVision(control);

		if(Vector3.Distance(spotter.position, target.position) >= lookRange)
		{
			return false;
		}
		else
		{
			Vector3 targetDir = (target.position - spotter.position).normalized;
			if(Vector3.Angle(spotter.forward, targetDir) > lookMaxAngle)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}

	private void setTarget(Enemy_StateController control)
	{
		if(control.chaseTarget == null)
		{
			if(target == null)
				target = GameObject.FindGameObjectWithTag("Player").transform;
		}
		else
		{
			target = control.chaseTarget;
		}
	}

	private void debugVision(Enemy_StateController control)	
	{
		Vector3 dirRight = Quaternion.AngleAxis(lookMaxAngle, Vector3.up) * control.eyes.forward;
		Vector3 leftRight = Quaternion.AngleAxis(-lookMaxAngle, Vector3.up) * control.eyes.forward;

		Debug.DrawRay(control.eyes.position, dirRight * lookRange, Color.green);
		Debug.DrawRay(control.eyes.position, leftRight * lookRange, Color.green);
	}
}