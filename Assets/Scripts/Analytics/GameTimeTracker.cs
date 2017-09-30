using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class GameTimeTracker : MonoBehaviour {
	
	static public GameTimeTracker instance = null;

	List<float> playTimes = new List<float>();
	float startPlayTime = 0.0f;

	void Awake() {
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(this);
		} else {
			Destroy(this);
		}
	}

	void OnEnable(){
		SceneManager.sceneLoaded += OnLevelLoaded;
		SceneManager.sceneUnloaded += OnLevelUnloaded;
	}

	void OnLevelLoaded(Scene scene, LoadSceneMode mode)
	{
		if(scene.name.Equals("Game")){
			startPlayTime = Time.time;
		}
	}

	void OnLevelUnloaded(Scene scene)
	{
		if(scene.name.Equals("Game")){
			float runPlayTime = Time.time - startPlayTime;
			playTimes.Add(runPlayTime);
		}
	}

	void OnApplicationQuit(){

		Debug.Log("Session Duration Event " + Analytics.CustomEvent("Session Duration", new Dictionary<string, object>
		{
			{ "Duration", Time.time }
		}));

		float totalPlayDuration = 0.0f;

		foreach (float duration in playTimes)
		{
			Debug.Log("Run Duration Event " + Analytics.CustomEvent("Run Duration", new Dictionary<string, object>
			{
				{ "Duration", duration }
			}));

			totalPlayDuration += duration;
		}

		Debug.Log("Total Play Duration Event " + Analytics.CustomEvent("Total Play Duration", new Dictionary<string, object>
		{
			{ "Duration", totalPlayDuration },
			{ "Runs Count", playTimes.Count }
		}));
	}
}
