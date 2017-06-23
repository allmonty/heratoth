using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerInputStrings {
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
}

public class PlayerInputReader : MonoBehaviour {

	[SerializeField] PlayerMovement playerMovement = null;
    [SerializeField] PlayerInputStrings inputStrings;

    float inputHorizontal = 0.0f;
    float inputVertical = 0.0f;

	void Update () {
        //PROCESS MOVEMENT
        inputHorizontal = Input.GetAxis(inputStrings.horizontalAxis);
        inputVertical = Input.GetAxis(inputStrings.verticalAxis);

        playerMovement.move(inputHorizontal, inputVertical);
    }
}
