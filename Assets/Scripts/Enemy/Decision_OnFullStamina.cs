using UnityEngine;

[CreateAssetMenu (menuName = "AI/Decisions/OnFullStamina")]
public class Decision_OnFullStamina : Decision {

	public override bool Decide(StateController controller) {
		return isStaminaFull(controller);
	}

	private bool isStaminaFull(StateController controller) {
		Enemy_StateController enemyController = controller as Enemy_StateController;

		var characterStamina = enemyController.characterStatus.stamina;
		if( characterStamina.isFull() ) {
			return true;
		}

		return false;
	}
}
