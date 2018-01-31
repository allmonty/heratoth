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
	public GameObject atomicModel;
	public GameObject singleEventModel;
	public GameObject chainEventModel;
	
	public int roundsCount = 0;
	public int selectedRound = 0;

	List<JToken> roundNodes = new List<JToken>(); 
	bool isReading = false;

	void Start() {
		if(this.loadSceneName)
			this.sceneName = SceneManager.GetActiveScene().name;
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
					roundNodes.Add(round["Nodes"]);
				}
			}

			roundsCount = roundNodes.Count;
			//Heroic Line of Master Access!!!
		}
	}

	void render() {
		foreach(var node in roundNodes[selectedRound])
		{
			Vector3 position = positionVectorFromNode(node);

			GameObject instantiatedNode = null;

			if(node["Type"].Value<string>() == "Atomic")
			{
				instantiatedNode = Instantiate(atomicModel, position, Quaternion.Euler(Vector3.up));
			}
			else if(node["Type"].Value<string>() == "Single Event") 
			{
				instantiatedNode = Instantiate(singleEventModel, position, Quaternion.Euler(Vector3.up));
			}
			else if(node["Type"].Value<string>() == "Chain Event") 
			{
				instantiatedNode = Instantiate(chainEventModel, position, Quaternion.Euler(Vector3.up));
			}

			int linkId = node["Link"].Value<int>();
			if(linkId != -1) {
				LineRenderer lineRenderer = instantiatedNode.GetComponent<LineRenderer>();
				Vector3 linkPosition = positionVectorFromNode(roundNodes[selectedRound][linkId]);
				Vector3[] positionsToLink = {position, linkPosition};				
				lineRenderer.SetPositions(positionsToLink);
			}
		}
	}

	Vector3 positionVectorFromNode(JToken node) {
		return new Vector3(
				node["Position"]["x"].Value<float>(),
				node["Position"]["y"].Value<float>(),
				node["Position"]["z"].Value<float>()
			);
	}
}
