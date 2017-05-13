using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Status_Life {

	public float maxLife = 10f;
	public float life = 10f;

	public UnityEvent callOnDeath;

	public void init() {
		life = maxLife;
	}

	public bool isEnough(float amount) {
		if(life >= amount){
			return true;
		}
		return false;
	}

	public void decrease(float amount) {
		life -= amount;

		if(life <= 0) {
			callOnDeath.Invoke();
            Debug.Log("OUT OF LIFE");
		}
	}

	public void increase(float amount) {
		life += amount;
		
		if(life > maxLife){
			life = maxLife;
		}
	}
}
