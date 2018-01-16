using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class GameFinishedTracker : MonoBehaviour {
	
	static public GameFinishedTracker instance = null;

	int goodEndsCount = 0;
	int badEndsCount = 0;

	void Awake() {
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(this);
		} else {
			Destroy(this);
		}
	}

	void addRelicEvent() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");

		TelemetryNode relicInteraction = new TelemetryNode(
			TelemetryNodeType.Activity,
			"Relic Found",
			player.transform.position
		);

		TelemetryCore.addNode(relicInteraction);
	}

	void registerEnding(string endingKey) {
		if(TelemetryCore.containsPlayerInfo(endingKey)) {
			int endsCounter = (int) TelemetryCore.getPlayerInfo(endingKey);
			TelemetryCore.setPlayerInfo(endingKey, endsCounter + 1 );
		} else {
			TelemetryCore.setPlayerInfo(endingKey, 1);
		}
	}

	public void triggerGoodEndGame()
	{
		goodEndsCount++;
		registerEnding("Good Endings");
		addRelicEvent();
	}

	public void triggerBadEndGame()
	{
		badEndsCount++;
		registerEnding("Bad Endings");		
		addRelicEvent();
	}

	void OnApplicationQuit(){

		Debug.Log("Finished Games Event " + Analytics.CustomEvent("Finished Games", new Dictionary<string, object>
		{
			{ "Good Ends", goodEndsCount },
			{ "Bad Ends", badEndsCount },
			{ "Total Ends", goodEndsCount + badEndsCount}
		}));
	}
}
