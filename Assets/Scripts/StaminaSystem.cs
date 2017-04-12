using UnityEngine;

public class StaminaSystem : MonoBehaviour {

	[SerializeField] float stamina = 10f;
	// [SerializeField] float replenishDelay = 3f;
	

	public bool isEnough(float amount) {
		if(stamina >= amount){
			return true;
		}
		return false;
	}

	public void decrease(float amount) {
		stamina -= amount;

		if(stamina <= 0) {
			Debug.Log("OUT OF STAMINA");
		}
	}
}
