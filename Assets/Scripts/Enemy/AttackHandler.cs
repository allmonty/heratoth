using UnityEngine;

public class AttackHandler : MonoBehaviour {

	[HideInInspector] public float damage;
	[HideInInspector] public float duration;
	[HideInInspector] public BoxCollider hitBox;

	private float timer = 0f;

	void Start() {
		hitBox = gameObject.GetComponent<BoxCollider>();
	}

	void Update()
	{
		timer += Time.deltaTime;
		if(timer >= duration) {
			timer = 0f;
			hitBox.enabled = false;
		}
	}

	void OnTriggerEnter(Collider other)	{
		bool isPlayer = other.GetComponent<Collider>().CompareTag("Player");

		if(isPlayer) {
			other.gameObject.GetComponent<CharacterStatus>().life.decrease(damage);
		}
	}
}
