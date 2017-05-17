using UnityEngine;

[CreateAssetMenu (menuName = "AI/Decisions/DecideOnTimer")]
public class Decision_DecideOnTimer : Decision {

	[SerializeField] float timeToDecide = 1f;
	float timer = 0f;

	public override bool Decide(StateController controller) {
		return decideOnTimer(controller as Enemy_StateController);
	}

	private bool decideOnTimer(Enemy_StateController controller) {
		timer += Time.deltaTime;
		if(timer > timeToDecide)
		{
			timer = 0f;
			return true;
		}
		else
		{
			return false;
		}
	}
}
