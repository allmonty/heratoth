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
		if(input != 0f)
		{
			if(currentAngle >= -maxAngle && currentAngle <= maxAngle){
				currentAngle += input * tiltSpeed * Time.deltaTime;
				transform.RotateAround(pivot.position, pivot.up, input * tiltSpeed * Time.deltaTime);
			}
		}
		else if(currentAngle != 0f)
		{
			float iteration = tiltBackSpeed * Time.deltaTime;
			float iterationToZero = -1 * Mathf.Sign(currentAngle) * iteration;
			currentAngle += iterationToZero;
			transform.RotateAround(pivot.position, pivot.up, iterationToZero);
			
			if(currentAngle >= -iteration && currentAngle <= iteration) currentAngle = 0f;
		}
	}
}
