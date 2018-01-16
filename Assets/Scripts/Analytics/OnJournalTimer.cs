using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Analytics;

public class OnJournalTimer : MonoBehaviour {

	bool tracking = false;
	float timer = 0f;
	float totalTime = 0f;

    public void startTimer() {
		tracking = true;
		timer += Time.deltaTime;
	}

	public void sendEvent() {
		totalTime = timer;
		timer = 0f;

		if (tracking) {
			dynamic additionalInfo = new ExpandoObject();
			additionalInfo.readingTime = totalTime;

			TelemetryNode journalNode = new TelemetryNode(
				TelemetryNodeType.Activity,
				transform.parent.name + " Reading",
				transform.position,
				additionalInfo
			);			
		
			TelemetryCore.addNode(journalNode);
		}

		tracking = false;
	}

	void Update()
	{
		if (tracking) {
			timer += Time.deltaTime;
		}
	}
}
