using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Enemy_Attack")]
public class Action_Attack : Action {
	[SerializeField] float staminaRequired = 2f;
	[SerializeField] float attackDelay = 1f;
	[SerializeField] float attackDuration = 1f;
	[SerializeField] float attackDamage = 1f;
	
	float timer;

	public override void Init() {
		timer = attackDelay;
	}
	
	public override void Act(StateController controller) {		
		attackRoutine(controller as Enemy_StateController);
	}

	private void attackRoutine(Enemy_StateController controller) {
		bool hasStamina = controller.characterStatus.stamina.isEnough(staminaRequired);

		if(hasStamina) {
			if(timer >= attackDelay) {
				performAttack(controller, attackDamage, attackDuration);
				timer = 0f;				
			} else {
				timer += Time.deltaTime;
			}
		} else {
			timer = attackDelay;	
		}
	}

	private void performAttack(Enemy_StateController controller, float attackDamage, float attackDuration) {
		controller.attackHandler.damage = attackDamage;
		controller.attackHandler.duration = attackDuration;
		controller.attackHandler.hitBox.enabled = true;
		controller.characterStatus.stamina.decrease(staminaRequired);
	}
}
