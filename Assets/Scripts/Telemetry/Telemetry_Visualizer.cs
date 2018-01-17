using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Telemetry_Visualizer : MonoBehaviour {

	public bool fetchInfo = false;

	List<JToken> roundNodes = new List<JToken>(); 
	bool isReading = false;

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
		//Debug.Log(info["-L3-eEUSlMmGZqnsfUXO"].GetType());
		foreach (var session in info) {
			foreach (var round in session.Value["Rounds"]) {
				roundNodes.Add(round["Nodes"]);
			}
			//Debug.Log(session.Value["Rounds"][0]["Nodes"]); o/
		}
	}

	void render() {
			}
		}
	}
}
