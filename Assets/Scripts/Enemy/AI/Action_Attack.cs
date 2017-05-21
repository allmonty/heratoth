using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Enemy_Attack")]
public class Action_Attack : Action
{
	public override void Init(StateController controller) {
		Debug.Log("ATTACK STATE");
	}
	
	public override void Act(StateController controller) {		
		attack(controller as Enemy_StateController);
	}

	private void attack(Enemy_StateController controller) {
		controller.attackHandler.lightAttack();
	}

	public override void Clear(StateController controller){
		var enemyControl = controller as Enemy_StateController;
        enemyControl.attackHandler.cutOffAttacking();
	}
}
