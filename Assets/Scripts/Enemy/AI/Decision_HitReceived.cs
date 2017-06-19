using UnityEngine;

[CreateAssetMenu (menuName = "AI/Decisions/HitReceived")]
public class Decision_HitReceived : Decision
{
	public override bool Decide(StateController controller) {
		return wasHit(controller as Enemy_StateController);
	}

	private bool wasHit(Enemy_StateController controller) {
		return false;//controller.hitProcessingVariables.wasHit;
	}
}
