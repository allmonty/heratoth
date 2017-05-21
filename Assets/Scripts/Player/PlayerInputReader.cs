using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerInputStrings {
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public string lightAttackButton = "Fire1";
	public string heavyAttackButton = "Fire2";
    public string dodgeButton = "Fire3";
}

public class PlayerInputReader : MonoBehaviour {

	[SerializeField] PlayerMovement playerMovement = null;
	[SerializeField] AttackHandler playerAttack = null;

    [SerializeField] PlayerInputStrings inputStrings;

    float inputHorizontal = 0.0f;
    float inputVertical = 0.0f;

    bool inputLightAttack = false;
    bool inputHeavyAttack = false;
    bool inputDodge = false;

	void Update () {
        //PROCESS MOVEMENT
        inputHorizontal = Input.GetAxis(inputStrings.horizontalAxis);
        inputVertical = Input.GetAxis(inputStrings.verticalAxis);

        playerMovement.move(inputHorizontal, inputVertical);

        //PROCESS ATTACK
        inputLightAttack = Input.GetButtonDown(inputStrings.lightAttackButton);
        inputHeavyAttack = Input.GetButtonDown(inputStrings.heavyAttackButton);

        if(inputLightAttack){ playerAttack.lightAttack(); }
        if(inputHeavyAttack){ playerAttack.heavyAttack(); }

        //PROCESS DODGE

        inputDodge = Input.GetButtonDown(inputStrings.dodgeButton);

        if(inputDodge){ playerMovement.dodge(inputHorizontal, inputVertical); }
    }
}
