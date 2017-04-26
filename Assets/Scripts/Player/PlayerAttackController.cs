using UnityEngine;
using System;

[Serializable]
public class PlayerAttackController {
	public CharacterStatus charStats = null;

	public float damage = 2f;
	public float staminaCost = 2f;
	public float attackDuration = 0.5f;

	public bool canAttack()
	{
		return charStats.stamina.isEnough(staminaCost);
	}

    public void processAttack()
    {
		charStats.stamina.decrease(staminaCost);
    }
}
