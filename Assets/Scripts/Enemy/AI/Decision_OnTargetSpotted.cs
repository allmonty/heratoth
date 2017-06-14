using UnityEngine;

[CreateAssetMenu (menuName = "AI/Decisions/TargetSpot")]
public class Decision_OnTargetSpotted : Decision
{
	[SerializeField] float lookRange = 5f;
	[SerializeField] float lookMaxAngle = 20f;

	public override bool Decide(StateController controller) {
		return TargetInSight(controller);
	}

	private bool TargetInSight(StateController controller) {
		var control = controller as Enemy_StateController;
		Transform spotter = control.gameObject.transform;

		debugVision(control);

		if(Vector3.Distance(spotter.position, control.chaseTarget.position) <= lookRange)
		{
			Vector3 targetDir = (control.chaseTarget.position - spotter.position).normalized;
			if(Vector3.Angle(spotter.forward, targetDir) <= lookMaxAngle)
			{
				RaycastHit hitInfo = new RaycastHit();
				if(Physics.Raycast(spotter.position, targetDir, out hitInfo, lookRange)){
					if(hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
					{
						return true;
					}
				}
			}
		}

		return false;
	}

	private void debugVision(Enemy_StateController control)	
	{
		Vector3 dirRight = Quaternion.AngleAxis(lookMaxAngle, Vector3.up) * control.eyes.forward;
		Vector3 leftRight = Quaternion.AngleAxis(-lookMaxAngle, Vector3.up) * control.eyes.forward;

		Debug.DrawRay(control.eyes.position, dirRight * lookRange, Color.green);
		Debug.DrawRay(control.eyes.position, leftRight * lookRange, Color.green);
	}
}