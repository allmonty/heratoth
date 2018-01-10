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

	public void triggerGoodEndGame()
	{
		goodEndsCount++;
		if(TelemetryController.containsPlayerInfo("Good Endings")) {
			int goodEndsCount = (int) TelemetryController.getPlayerInfo("Good Endings");
			TelemetryController.setPlayerInfo("Good Endings", badEndsCount + 1 );
		} else {
			TelemetryController.setPlayerInfo("Good Endings", 1);
		}

	}

	public void triggerBadEndGame()
	{
		badEndsCount++;
		if(TelemetryController.containsPlayerInfo("Bad Endings")) {
			int badEndsCount = (int) TelemetryController.getPlayerInfo("Bad Endings");
			TelemetryController.setPlayerInfo("Bad Endings", badEndsCount + 1 );
		} else {
			TelemetryController.setPlayerInfo("Bad Endings", 1);
		}
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
