using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotMovement : MonoBehaviour {

	[SerializeField] Transform pivot = null;
	[SerializeField] float tiltSpeed = 50.0F;
	[SerializeField] float tiltBackSpeed = 150.0F;
	[SerializeField] float maxAngle = 30.0F;
	
	[Space(10f)]

	[SerializeField] string rotationInput = "CameraHorizontalTilt";
	
	float currentAngle = 0f;

	void LateUpdate ()
	{
		var input = Input.GetAxis(rotationInput);

		if(input > 0f && currentAngle < maxAngle) {
			currentAngle += input * tiltSpeed * Time.deltaTime;
			transform.RotateAround(pivot.position, pivot.up, input * tiltSpeed * Time.deltaTime);
		} else if(input < 0f && currentAngle > -maxAngle) {
			currentAngle += input * tiltSpeed * Time.deltaTime;
			transform.RotateAround(pivot.position, pivot.up, input * tiltSpeed * Time.deltaTime);
		}
	}
}
