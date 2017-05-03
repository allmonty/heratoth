using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Enemy_Attack")]
public class Action_Attack : Action {
	[SerializeField] float staminaRequired = 2f;
	[SerializeField] float attackDelay     = 1f;
	[SerializeField] float attackDuration  = 1f;
	[SerializeField] float attackDamage    = 1f;
	[SerializeField] float attackRange     = 2f;

	[SerializeField] float timer;

	public override void Init() {
		timer = attackDelay;
	}
	
	public override void Act(StateController controller) {		
		attackRoutine(controller as Enemy_StateController);
	}

	private void attackRoutine(Enemy_StateController controller) {
		Vector3 targetPosition = controller.chaseTarget.transform.position;
		float distanceFromTarget = getDistanceFromTarget(targetPosition, controller);

		bool hasStamina = controller.characterStatus.stamina.isEnough(staminaRequired);

		if(hasStamina) {
			if(timer >= attackDelay) {
				timer = attackDelay;
				if(distanceFromTarget <= attackRange) {
					performAttack(controller, attackDamage, attackDuration);
					timer = 0f;
				}
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

	private float getDistanceFromTarget(Vector3 targetPosition, Enemy_StateController controller) {
		Vector3 originPosition = controller.eyes.position;
		Vector3 originToTargetVector = targetPosition - originPosition;
		float distanceFromTarget = originToTargetVector.magnitude;
		
		return distanceFromTarget;
	}
}
