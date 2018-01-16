using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Telemetry_Visualizer : MonoBehaviour {

	public bool fetchInfo = false;
	bool isReading = false;

	void Update () {
		if(fetchInfo) {
			fetchInfo = false;
			TelemetryCore.loadSessionsData("Users");
			isReading = true;
		}
		
		if(isReading) {
			if(TelemetryCore.getSessionsData() != null) {
				Debug.Log(TelemetryCore.getSessionsData());
				isReading = false;
			}
		}
	}
}
