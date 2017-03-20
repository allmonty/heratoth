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
            Vector3 moveDirection = processDirectionInRelationToCamera(inputHorizontal, 0.0f, inputVertical);
            if(moveDirection.magnitude > 1) moveDirection.Normalize();

            playerMovement.moveHorizontal(moveDirection.x, moveDirection.z);
        }
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
