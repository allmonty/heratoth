using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerInputStrings {
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public string lightAttackButton = "Fire1";
	public string heavyAttackButton = "Fire2";
}

public class PlayerInputReader : MonoBehaviour {

	[SerializeField] PlayerMovement playerMovement = null;
	[SerializeField] PlayerAttack playerAttack = null;

    [SerializeField] PlayerInputStrings inputStrings;

    float inputHorizontal = 0.0f;
    float inputVertical = 0.0f;

    bool inputLightAttack = false;
    bool inputHeavyAttack = false;

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
    }
}
