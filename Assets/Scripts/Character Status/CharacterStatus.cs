using UnityEngine;

public class CharacterStatus : MonoBehaviour {

	public Status_Life life;
	public Status_Stamina stamina;

	void Awake() {
		life.init();
		stamina.init();
	}

	void Update() {
		stamina.update();
	}
}
