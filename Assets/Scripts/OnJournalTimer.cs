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

	public void stopTimer() {
		tracking = false;
		totalTime = timer;
		timer = 0f;
	}

	public void sendEvent(string eventName) {
		Debug.Log("Send event: " + eventName);
		
		Analytics.CustomEvent(eventName);
		
		// Analytics.CustomEvent(eventName, new Dictionary<string, object>
		// {
		// 	{ "Time", totalTime }
		// });
	}

	void Update()
	{
		if (tracking) {
			timer += Time.deltaTime;
		}
	}
}
