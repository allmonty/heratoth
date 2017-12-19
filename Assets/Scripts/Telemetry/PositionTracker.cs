using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PositionTracker : MonoBehaviour {

	[SerializeField] float trackingDelay = 0f;

	List<Vector3> positionsTracked = new List<Vector3>();

	void Start () {
		InvokeRepeating("track", 0f, trackingDelay);		
	}

	void track() {
		positionsTracked.Add(transform.position);
	}

	void OnDestroy() {
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/playerPosition.json", true);
		
		PlayerPositions data = new PlayerPositions();

		foreach (Vector3 position in positionsTracked)
		{
			PlayerPosition playerPos = new PlayerPosition();
			playerPos.init(position);
			data.positions.Add(playerPos);
		}

		writer.Flush();
        writer.WriteLine(JsonUtility.ToJson(data));
        writer.Close();
	}
}

[System.Serializable]
public class PlayerPositions {
	public List<PlayerPosition> positions = new List<PlayerPosition>();
}

[System.Serializable]
public class PlayerPosition {
	public float posX;
	public float posY;
	public float posZ;

	public void init(Vector3 pos) {
		posX = pos.x;
		posY = pos.y;
		posZ = pos.z;
	}

	public Vector3 getVector() {
		return new Vector3(posX, posY, posZ);
	}
}
