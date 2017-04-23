using UnityEngine;

public class CharacterStatus : MonoBehaviour {

	public Status_Stamina stamina;

	void Awake() {
		stamina.init();
	}

	void Update() {
		stamina.update();
	}
}
