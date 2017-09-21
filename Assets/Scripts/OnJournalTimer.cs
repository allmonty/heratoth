using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class OnJournalTimer : MonoBehaviour {

	bool tracking = false;
	float timer = 0f;
	float totalTime = 0f;
	
	public string eventName = "teste";
    public bool execute = false;

    public void startTimer() {
		tracking = true;
		timer += Time.deltaTime;
	}

	public void stopTimer() {
		tracking = false;
		totalTime = timer;
		timer = 0f;
	}

	public void sendEvent(string eventName) {
		var analyticsStatus = Analytics.CustomEvent(eventName, new Dictionary<string, object>
		{
			{ "Time", totalTime }
		});

		Debug.Log("Event: " + eventName + " | Status: " + analyticsStatus);
	}

	void Update()
	{
		if (tracking) {
			timer += Time.deltaTime;
		}

		if(execute)
		{
			sendEvent(eventName);
			execute = false;
		}
	}
}
