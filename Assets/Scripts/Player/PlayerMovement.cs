using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public PlayerMovementController movementController;

	Rigidbody rigid;

	void Start () {
		rigid = GetComponent<Rigidbody> ();
	}

	public void moveHorizontal(float dirX, float dirZ) {
		rigid.velocity = movementController.getHorizontalVelocity(dirX, dirZ, rigid.velocity.y);

        transform.LookAt(transform.position + new Vector3(dirX, 0.0f, dirZ), Vector3.up);
	}
}
