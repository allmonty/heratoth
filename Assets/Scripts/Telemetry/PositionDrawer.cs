using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Dynamic;

[ExecuteInEditMode]
public class PositionDrawer : MonoBehaviour {

	public bool runDrawer = false;

	List<PlayerPosition> positions = new List<PlayerPosition>();

	void Update() {
		if(runDrawer)
		{
			string path = Application.persistentDataPath + "/playerPosition2.json";

			StreamReader reader = new StreamReader(path);
			
			Dictionary<string, object> data = JsonUtility.FromJson<Dictionary<string, object>>(reader.ReadToEnd());
			
			Debug.Log("Teste: " + data);

			positions = new List<PlayerPosition>(data["positions"] as List<PlayerPosition>);

			reader.Close();
			runDrawer = false;
		}
	}
	
	void OnDrawGizmos () {
		for(int i = 0; i < positions.Count - 1; i++)
		{
			Gizmos.color = new Color(1f, 0f, 0f);
			Gizmos.DrawLine(positions[i].getVector(), positions[i+1].getVector());
			Gizmos.DrawCube(positions[i].getVector(), new Vector3(1, 1, 1));
		}
	}
}
