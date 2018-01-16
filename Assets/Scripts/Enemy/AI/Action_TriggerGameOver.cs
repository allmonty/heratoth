using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu (menuName = "AI/Actions/TriggerGameOver")]
public class Action_TriggerGameOver : Action
{
	public override void Init(StateController controller) {
		if(TelemetryCore.containsPlayerInfo("Deaths")) {
			int gameOverCounter = (int) TelemetryCore.getPlayerInfo("Deaths");
			TelemetryCore.setPlayerInfo("Deaths", gameOverCounter + 1 );
		} else {
			TelemetryCore.setPlayerInfo("Deaths", 1);
		}

		GameObject player = GameObject.FindGameObjectWithTag("Player");

		TelemetryNode deathNode = new TelemetryNode(
			TelemetryNodeType.Agent,
			"Player Spotted",
			player.transform.position
		);

		TelemetryCore.addNode(deathNode);

		GameManager.instance.gameOver();
	}

	public override void Act(StateController controller)
	{
		return;
	}
	
	public override void Clear(StateController controller){
		return;
	}
}