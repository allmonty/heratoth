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
			hitBox.enabled = false;
			timer = 0f;
		}
	}

	void OnTriggerEnter(Collider other)	{
		bool isPlayer = other.GetComponent<Collider>().CompareTag("Player");

		if(isPlayer) {
			// Debug.Log("ATTACK");
		}		
	}
}
