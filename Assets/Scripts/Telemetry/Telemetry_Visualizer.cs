using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Telemetry_Visualizer : MonoBehaviour {

	public string sceneName = "";
	public bool loadSceneName = true;
	public bool fetchInfo = false;
	
	public int roundsCount = 0;
	public int selectedRound = 0;

	List<JToken> roundNodes = new List<JToken>(); 
	bool isReading = false;

	LineRenderer lineRenderer = null;

	void Start() {
		if(this.loadSceneName)
			this.sceneName = SceneManager.GetActiveScene().name;
		this.lineRenderer = transform.GetComponent<LineRenderer>();
	}

	void Update () {
		if(fetchInfo) {
			fetchInfo = false;
			TelemetryCore.loadSessionsData("Users");
			isReading = true;
		}
		
		if(isReading) {
			if(TelemetryCore.getSessionsData() != null) {
				setup(TelemetryCore.getSessionsData());
				render();
				isReading = false;
			}
		}
	}


	void setup(string data) {
		JObject info = JObject.Parse(data);
		foreach (var session in info) {
			foreach (var round in session.Value["Rounds"]) {
				if (round["Scene Name"].Value<string>() == this.sceneName) {
					Debug.Log(round);
					roundNodes.Add(round["Nodes"]);
				}
			}

			roundsCount = roundNodes.Count;
			//Heroic Line of Master Access!!!
			// Debug.Log(session.Value["Rounds"][0]["Nodes"]); //o/
		}
		Debug.Log(roundNodes);
	}

	void render() {
		List<Vector3> positions = new List<Vector3>();
		foreach(var node in roundNodes[selectedRound]) {
			Debug.Log(node["Position"]);
			if(node["Name"].Value<string>() == "Player Position" &&
				node["Type"].Value<string>() == "Agent"){
				Vector3 position = new Vector3(
					node["Position"]["x"].Value<float>(),
					node["Position"]["y"].Value<float>(),
					node["Position"]["z"].Value<float>()
				);
				positions.Add(position);
			}
		}

		lineRenderer.positionCount = positions.Count;
		lineRenderer.SetPositions(positions.ToArray());
	}
}
