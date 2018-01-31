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

		TelemetryNode enemySpotPlayer = new TelemetryNode(
			TelemetryNodeType.ChainEvent,
			"Enemy spotted player",
			controller.transform.position
		);

		int eventId = TelemetryCore.addNode(enemySpotPlayer);

		TelemetryNode playerSpotted = new TelemetryNode(
			TelemetryNodeType.ChainEvent,
			"Player Spotted",
			player.transform.position
		);

		playerSpotted.setLink(eventId);
		TelemetryCore.addNode(playerSpotted);

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