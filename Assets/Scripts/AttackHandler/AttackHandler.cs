using UnityEngine;

public class AttackHandler : MonoBehaviour {

	[SerializeField] CharacterStatus charStats = null;
	[SerializeField] GameObject attackBox = null;
	[SerializeField] AttackStatus lightAttackStats;
	[SerializeField] AttackStatus heavyAttackStats;
	[SerializeField] string animationParam = "attack";

	AttackStatus currentAtkStats = null;

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
	}

	public void endAnimations()
	{
		anim.SetInteger(animationParam, 0);
	}

	private void startAttack()
	{
		anim.SetInteger(animationParam, attackAnimVal);
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
		anim.SetInteger(animationParam, 0);
		attackBox.SetActive(false);
		isAttacking = false;
	}

	private bool canAttack(float staminaCost)
	{
		return charStats.stamina.isEnough(staminaCost) && !isAttacking;
	}
}
