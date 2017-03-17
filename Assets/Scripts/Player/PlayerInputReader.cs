using UnityEngine;
using System.Collections;

public class PlayerInputReader : MonoBehaviour {

	[SerializeField] PlayerMovement playerMovement = null;

    float inputHorizontal = 0.0f;
    float inputVertical = 0.0f;

	void Update () {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        if(inputHorizontal != 0.0f || inputVertical != 0.0f)
        {
            Vector3 moveDirection = new Vector3(inputHorizontal, 0.0f, inputVertical);
            Quaternion cameraLookDir = Camera.main.transform.rotation;
            cameraLookDir.x = 0.0f;

            moveDirection = cameraLookDir * moveDirection;
            playerMovement.moveHorizontal(moveDirection.x, moveDirection.z);
        }	
	}
}
