using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Enemy_Attack")]
public class Enemy_AttackAction : Action {
	
	[SerializeField] StaminaSystem stamina;
	[SerializeField] float staminaRequired = 2f;
	[SerializeField] float attackDelay = 5f;
	
	float timer = 0f;
	
	public override void Act(StateController controller) {
		Attack(controller as Enemy_StateController); // Check
	}

	private void Attack(Enemy_StateController controller) {
		if(timer >= attackDelay && controller.stamina.isEnough(staminaRequired)) {
			Debug.Log("ATTACK");
			controller.stamina.decrease(staminaRequired);
			timer = 0f;
		} else {
			timer += Time.deltaTime;
		}
	}
}
