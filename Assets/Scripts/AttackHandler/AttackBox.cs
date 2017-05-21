using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackBox : MonoBehaviour {

	[Serializable] public class CallBack : UnityEvent <CharacterStatus> {};
	public CallBack callBack;

	public string layerToHit = "Enemy";

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.layer == LayerMask.NameToLayer(layerToHit))
		{
			CharacterStatus enemyStatus = col.gameObject.GetComponent<CharacterStatus>();
			if(enemyStatus == null)
				enemyStatus = col.gameObject.GetComponentInParent<CharacterStatus>();

			callBack.Invoke(enemyStatus);
		}
	}
}
