using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotMovement : MonoBehaviour {

	[SerializeField] Transform pivot = null;
	[SerializeField] float speed = 2.0F;
	
	[Space(10f)]

	[SerializeField] string rotationInput = "Horizontal";

	void LateUpdate ()
	{
		var input = Input.GetAxis(rotationInput);
		transform.RotateAround(pivot.position, Vector3.up, input * speed * Time.deltaTime);
	}
}
