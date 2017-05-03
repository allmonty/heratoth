using UnityEngine;

[CreateAssetMenu (menuName = "AI/Decisions/LowOnStamina")]
public class Decision_LowOnStamina : Decision {

	[SerializeField] float lowStamina;

	public override bool Decide(StateController controller) {
		return isLowOnStamina(controller);
	}

	private bool isLowOnStamina(StateController controller) {
		Enemy_StateController enemyController = controller as Enemy_StateController;

		var characterStamina = enemyController.characterStatus.stamina;
		if( characterStamina.stamina <= lowStamina ) {
			return true;
		}

		return false;
	}
}
