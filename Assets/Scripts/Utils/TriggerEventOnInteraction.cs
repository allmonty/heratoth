using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventOnInteraction : MonoBehaviour {

	public UnityEvent eventOnInteraction;
	public UnityEvent eventOnExit;

	public string layerToDetect = "Player";

	public string triggerButton = "Fire1";

	private bool triggered = false;

	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.layer == LayerMask.NameToLayer(layerToDetect))
		{
			if(Input.GetButtonDown(triggerButton))
			{
				if(!triggered)
					eventOnInteraction.Invoke();
				else
					eventOnExit.Invoke();

				triggered = !triggered;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		eventOnExit.Invoke();
	}
}
