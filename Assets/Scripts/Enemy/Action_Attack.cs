using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Enemy_Attack")]
public class Action_Attack : Action {
	[SerializeField] float staminaRequired = 2f;
	[SerializeField] float attackDelay = 5f;
	
	float timer = 0f;
	
	public override void Act(StateController controller) {
		attack(controller as Enemy_StateController); // Check
	}

	private void attack(Enemy_StateController controller) {
		if(timer >= attackDelay && controller.characterStatus.stamina.isEnough(staminaRequired)) {
			Debug.Log("ATTACK");
			controller.characterStatus.stamina.decrease(staminaRequired);
			timer = 0f;
		} else {
			timer += Time.deltaTime;
		}
	}
}
