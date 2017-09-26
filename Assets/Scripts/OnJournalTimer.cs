using System.Collections;
using System.Collections.Generic;
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
			var eventName = "Reading Time of " + transform.parent.name;
			var analyticsStatus = Analytics.CustomEvent(eventName, new Dictionary<string, object>
			{
				{ "Reading Time", totalTime }
			});

			Debug.Log("Event: " + eventName + " | Status: " + analyticsStatus);
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
