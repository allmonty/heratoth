using UnityEngine;

[CreateAssetMenu (menuName = "AI/Decisions/TargetSpot")]
public class Decision_OnTargetSpotted : Decision {
	
	[SerializeField] float lookRange;
	[SerializeField] string targetTag;

	public override bool Decide(StateController controller) {
		return TargetInSight(controller);
	}

	private bool TargetInSight(StateController controller) {
		Enemy_StateController control = controller as Enemy_StateController;
		
		RaycastHit hit;		
		Debug.DrawRay(control.eyes.position, control.eyes.forward.normalized * lookRange, Color.green);

		Vector3 origin = control.eyes.position;
		Vector3 direction = control.eyes.forward;

		if( Physics.Raycast(origin, direction, out hit) && hit.collider.CompareTag("Player") ) {
			return true;
		}
		else {
			return false;
		}
	}
}