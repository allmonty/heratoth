using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public PlayerMovementController movementController;
	Rigidbody rigid;
	Animator anim;

	void Start () {
		rigid = GetComponent<Rigidbody>();
		anim = GetComponentInChildren<Animator>();
	}

	public void move(float dirX, float dirZ){
		if(dirX == 0.0f && dirZ == 0.0f)
        {
            anim.SetBool("isMoving", false);
        }
		else{
			Vector3 moveDirection = processDirectionInRelationToCamera(dirX, 0.0f, dirZ);
            if(moveDirection.magnitude > 1) moveDirection.Normalize();

            moveHorizontal(moveDirection.x, moveDirection.z);
		}
	}

	public void moveHorizontal(float dirX, float dirZ) {
		anim.SetBool("isMoving", true);

		rigid.velocity = movementController.getHorizontalVelocity(dirX, dirZ, rigid.velocity.y);

        transform.LookAt(transform.position + new Vector3(dirX, 0.0f, dirZ), Vector3.up);
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
