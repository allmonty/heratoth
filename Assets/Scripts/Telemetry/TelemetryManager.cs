using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelemetryManager : MonoBehaviour {

	static public TelemetryManager instance = null;

	public List<string> playableScenes = new List<string>();

	bool isRoundRunning = false;

	void Awake() {
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(this);
		} else {
			Destroy(this);
		}
	}

	void OnEnable()	{
		Debug.Log("Enabled");
		SceneManager.sceneLoaded += OnSceneLoaded;
		SceneManager.sceneUnloaded += OnSceneUnloaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)	{
		if(playableScenes.Contains(scene.name)) {
			this.isRoundRunning = true;
			Debug.Log("Loaded " + scene.name);
			TelemetryController.newRound(scene.name);
		}
	}

	void OnSceneUnloaded(Scene scene)	{
		if(playableScenes.Contains(scene.name)) {
			this.isRoundRunning = false;
			Debug.Log("Unloaded " + scene.name);
			TelemetryController.endRound();
		}
	}

	void OnDisable()	{
		Debug.Log("Disabled");
		SceneManager.sceneLoaded -= OnSceneLoaded;
		SceneManager.sceneUnloaded -= OnSceneUnloaded;
	}

	void OnApplicationQuit() {
		if(this.isRoundRunning) {
			TelemetryController.endRound();
		}

		TelemetryController.setPlayerInfo("Session Duration", Time.realtimeSinceStartup);

		Debug.Log(JsonConvert.SerializeObject(TelemetryController.getPlayerInfo()));
	}
}
