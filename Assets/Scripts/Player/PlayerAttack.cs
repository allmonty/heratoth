using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public PlayerAttackController attackController;

	public GameObject attackBox = null;

	public void attack() {
		if(attackController.canAttack())
		{
			attackController.processAttack();
			
			attackBox.SetActive(true);
		}
	}

	public void doDamage(CharacterStatus enemy)
	{
		enemy.life.decrease(attackController.damage);
		attackBox.SetActive(false);
	}
}
