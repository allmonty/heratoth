using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	[SerializeField] CharacterStatus charStats = null;
	[SerializeField] GameObject attackBox = null;
	[SerializeField] PlayerAttackStatus lightAttackStats;
	[SerializeField] PlayerAttackStatus heavyAttackStats;

	PlayerAttackStatus currentAtkStats = null;
	Animator anim = null;
	int attackAnimVal = 0;
	bool isAttacking = false;

	void Start()
	{
		anim = GetComponentInChildren<Animator>();
	}

	public void lightAttack()
	{
		if(canAttack(lightAttackStats.staminaCost))
		{
			currentAtkStats = lightAttackStats;
			attackAnimVal = 1;
			startAttack();
		}
	}

	public void heavyAttack()
	{
		if(canAttack(heavyAttackStats.staminaCost))
		{
			currentAtkStats = heavyAttackStats;
			attackAnimVal = 2;
			startAttack();
		}
	}

	public void doDamage(CharacterStatus enemy)
	{
		enemy.life.decrease(currentAtkStats.damage);
		endAttack();
	}

	private void startAttack()
	{
		anim.SetInteger("attack", attackAnimVal);
		isAttacking = true;
		charStats.stamina.decrease(currentAtkStats.staminaCost);
		Invoke("activateAttack", currentAtkStats.attackDelay);
	}

	private void activateAttack()
	{
		attackBox.SetActive(true);
		Invoke("endAttack", currentAtkStats.attackDuration);
	}

	private void endAttack()
	{
		anim.SetInteger("attack", 0);
		attackBox.SetActive(false);
		isAttacking = false;
	}

	private bool canAttack(float staminaCost)
	{
		return charStats.stamina.isEnough(staminaCost) && !isAttacking;
	}
}
