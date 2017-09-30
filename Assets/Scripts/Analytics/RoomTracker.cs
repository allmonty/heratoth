using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class RoomTracker : MonoBehaviour {

	[SerializeField] string currentRoom = "";
	float timeWhenEnteredRoom = 0.0f;

	void Awake()
	{
		timeWhenEnteredRoom = Time.time;
	}

	public void walkedThroughDoor(string room1, string room2)
	{
		string previousRoom = "";
		if(currentRoom.Equals(room1))
		{
			previousRoom = room1;
			currentRoom = room2;
		}
		else
		{
			previousRoom = room2;
			currentRoom = room1;
		}

		float timeInRoom = Time.time - timeWhenEnteredRoom;

		Debug.Log("Time in Room: " + previousRoom + " " +
			Analytics.CustomEvent("Time in Room: " + previousRoom, new Dictionary<string, object>
		{
			{ "Duration", timeInRoom }
		}));

		timeWhenEnteredRoom = Time.time;
	}
}
