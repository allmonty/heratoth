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
	}

	public void triggerBadEndGame()
	{
		badEndsCount++;
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
