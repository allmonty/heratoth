using UnityEngine;

[CreateAssetMenu (menuName = "AI/Decisions/SoundHeard")]
public class Decision_SoundHeard : Decision
{
	public override bool Decide(StateController controller) {
		return heardSound(controller as Enemy_StateController);
	}

	private bool heardSound(Enemy_StateController controller) {
		if(controller.heardSound)
		{
			controller.heardSound = false;
			return true;
		}

		return false;
	}
}
