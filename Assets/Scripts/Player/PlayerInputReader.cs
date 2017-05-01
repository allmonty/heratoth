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

        if(inputHorizontal != 0.0f || inputVertical != 0.0f)
        {
            Vector3 moveDirection = processDirectionInRelationToCamera(inputHorizontal, 0.0f, inputVertical);
            if(moveDirection.magnitude > 1) moveDirection.Normalize();

            playerMovement.moveHorizontal(moveDirection.x, moveDirection.z);
        }

        //PROCESS ATTACK
        inputLightAttack = Input.GetButtonDown(inputStrings.lightAttackButton);
        inputHeavyAttack = Input.GetButtonDown(inputStrings.heavyAttackButton);

        if(inputLightAttack){ playerAttack.lightAttack(); }
        if(inputHeavyAttack){ playerAttack.heavyAttack(); }
    }

    private Vector3 processDirectionInRelationToCamera(float x, float y, float z)
    {
        Vector3 direction = new Vector3(x, y, z);
        Quaternion cameraRotation = Camera.main.transform.rotation;

        cameraRotation.x = 0.0f; //removes the vertical rotation

        direction = cameraRotation * direction;
        return direction;
    }
}
