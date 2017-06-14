using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target = null;

	public float smoothing = 5f;

	public Vector3 offset = Vector3.zero;

	public bool dynamicOffset = false;
	
	void Start()
	{
		if(target == null) target = GameObject.FindGameObjectWithTag("Player").transform;

		if(dynamicOffset) offset = transform.position - target.position;
	}

	void FixedUpdate()
	{
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}

