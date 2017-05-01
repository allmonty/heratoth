using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	[SerializeField] CharacterStatus charStats = null;
	[SerializeField] GameObject attackBox = null;
	[SerializeField] PlayerAttackStatus lightAttackStats;
	[SerializeField] PlayerAttackStatus heavyAttackStats;

	PlayerAttackStatus currentAtkStats = null;

	bool isAttacking = false;

	public void lightAttack()
	{
		currentAtkStats = lightAttackStats;
		if(canAttack()) startAttack();
	}
	
	public void heavyAttack()
	{
		currentAtkStats = heavyAttackStats;
		if(canAttack()) startAttack();
	}

	public void doDamage(CharacterStatus enemy)
	{
		enemy.life.decrease(currentAtkStats.damage);
		endAttack();
	}

	private void startAttack()
	{
		if(!isAttacking)
		{
			attackBox.SetActive(true);
			isAttacking = true;
			charStats.stamina.decrease(currentAtkStats.staminaCost);
			Invoke("endAttack", currentAtkStats.attackDuration);
		}
	}

	private void endAttack()
	{
		attackBox.SetActive(false);
		isAttacking = false;
	}

	private bool canAttack()
	{
		return charStats.stamina.isEnough(currentAtkStats.staminaCost) && !isAttacking;
	}
}
