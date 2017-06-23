using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffectController : MonoBehaviour {

	public Light lightComponent = null;
	public float minIntensity = 2f;
	public float maxIntensity = 3f;
	public float minTimeToCrackle = 0.05f;
	public float maxTimeToCrackle = 0.3f;
	public float timeToCrackle = 0.2f;

	float timer = 0f;

	void Start () {
		if(lightComponent == null)
			lightComponent = GetComponent<Light>();
	}
	
	void Update () {
		timer += Time.deltaTime;
		if(timer >= timeToCrackle)
		{
			lightComponent.intensity = Random.Range(minIntensity, maxIntensity);
			timeToCrackle = Random.Range(minTimeToCrackle, maxTimeToCrackle);
			timer = 0f;
		}
	}
}
