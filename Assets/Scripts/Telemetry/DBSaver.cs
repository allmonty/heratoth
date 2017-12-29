
using UnityEngine;

public class DBSaver: ScriptableObject{

	static DBSaver_Firebase firebase = new DBSaver_Firebase();

	public static void savePlayerData(string json) {
		firebase.savePlayerData(json);
	}
}
