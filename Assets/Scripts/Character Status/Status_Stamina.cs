using System;
using UnityEngine;

[Serializable]
public class Status_Stamina {

	public int stamina = 10;

	public bool isEnough(int amount) {
		if(stamina >= amount){
			return true;
		}
		return false;
	}

	public void decrease(int amount) {
		stamina -= amount;

		if(stamina <= 0) {
            Debug.Log("OUT OF STAMINA");
		}
	}
}
