using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Status_Stamina {

	public float maxStamina = 10f;
	public float stamina = 10f;

	public float secondsToRegen = 3f;
	public float regenRatePerSecond = 1f;

	[Serializable] public class CallBack : UnityEvent <float> {};
	public CallBack callBackOnChange;

	private float timerToRegen = 0f;

	public void init() {
		stamina = maxStamina;
	}

	public void update() {
		if(timerToRegen > 0f){
			timerToRegen -= Time.deltaTime;
		}
		else{
			increase(regenRatePerSecond * Time.deltaTime);
		}
	}

	public bool isEnough(float amount) {
		if(stamina >= amount){
			return true;
		}
		return false;
	}

	public bool isFull() {
		if(stamina == maxStamina){
			return true;
		}
		return false;
	}

	public void decrease(float amount) {
		stamina -= amount;
		
		if(stamina < 0) {
			stamina = 0;
		}

		timerToRegen = secondsToRegen;
		callBackOnChange.Invoke(stamina/maxStamina);
	}

	public void increase(float amount) {
		stamina += amount;
		
		if(stamina > maxStamina){
			stamina = maxStamina;
		}

		callBackOnChange.Invoke(stamina/maxStamina);
	}
}
