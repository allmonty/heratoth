using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackBox : MonoBehaviour {

	[Serializable] public class CallBack : UnityEvent <CharacterStatus> {};
	public CallBack callBack;

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			CharacterStatus enemyStatus = col.gameObject.GetComponent<CharacterStatus>();
			callBack.Invoke(enemyStatus);
		}
	}
}
