using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterBehaviour : MonoBehaviour {

	public string interactedName = "";

	public UnityEvent eventCaller;

	void OnTriggerEnter(Collider col){
		if(col.name == interactedName)
			eventCaller.Invoke();
	}
}
