using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PlayerMovementController {

	public float speed = 2.0F;

	public Vector3 getHorizontalVelocity(float dirX, float dirZ, float gravity)
	{
		return new Vector3 (dirX * speed, gravity, dirZ * speed);
	}
}
