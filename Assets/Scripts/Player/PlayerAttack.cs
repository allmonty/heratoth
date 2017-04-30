using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public PlayerAttackController atkCont;

	public GameObject attackBox = null;

	public void attack() {
		if(atkCont.canAttack())
		{
			startAttack();
		}
	}

	public void doDamage(CharacterStatus enemy)
	{
		enemy.life.decrease(atkCont.damage);
		endAttack();
	}

	private void startAttack()
	{
		if(!atkCont.isAttacking)
		{
			attackBox.SetActive(true);
			atkCont.isAttacking = true;
			atkCont.processAttack();
			Invoke("endAttack", atkCont.attackDuration);
		}
	}

	private void endAttack()
	{
		attackBox.SetActive(false);
		atkCont.isAttacking = false;
	}
}
